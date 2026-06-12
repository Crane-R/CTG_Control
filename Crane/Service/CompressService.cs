using CTG_Control.Crane.Constant;
using CTG_Control.Crane.Model.Bean;
using CTG_Control.Crane.Model.Dao;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CTG_Control.Crane.Service
{
    /// <summary>
    /// 压缩服务
    /// </summary>
    internal class CompressService
    {

        private static readonly string WINRAR_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe";

        private CompressService() { }

        /// <summary>
        /// 检查是否安装winrar
        /// </summary>
        /// <returns></returns>
        public static bool NotExistsWinRar()
        {
            string result = string.Empty;
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(WINRAR_KEY);
            if (registryKey != null)
            {
                result = registryKey.GetValue("").ToString();
            }
            registryKey.Close();

            return "".Equals(result);
        }

        /// <summary>
        /// 将格式为rar的压缩文件解压到指定的目录
        /// </summary>
        /// <param name="rarFileName">要解压rar文件的路径</param>
        /// <param name="saveDir">解压后要保存到的目录</param>
        public static void DeCompressRar(string rarFileName, string saveDir)
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(WINRAR_KEY);
            string winrarPath = registryKey.GetValue("").ToString();
            registryKey.Close();
            string winrarDir = Path.GetDirectoryName(winrarPath);
            String commandOptions = string.Format("x {0} {1} -ibck -y", rarFileName, saveDir);

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = System.IO.Path.Combine(winrarDir, "rar.exe");
            processStartInfo.Arguments = commandOptions;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
            process.Close();
        }

        /// <summary>
        /// 压缩核心
        /// </summary>
        /// <param name="compressItem"></param>
        public static void CompressRar(CompressItem compressItem)
        {
            CompressRarAsync(compressItem, null).GetAwaiter().GetResult();
        }

        public static async Task CompressRarAsync(CompressItem compressItem, IProgress<int>? progress)
        {
            string sourcePath = compressItem.SourcePath;
            if (sourcePath is null)
            {
                return;
            }

            string targetPath = GetTargetDirectory(compressItem);
            Directory.CreateDirectory(targetPath);
            string targetFileName = targetPath + "\\" + compressItem.Id + "_" + compressItem.MarkName + "@.rar";

            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(WINRAR_KEY);
            string winrarPath = registryKey.GetValue("").ToString();
            registryKey.Close();
            string winrarDir = Path.GetDirectoryName(winrarPath);
            string rarPath = Path.Combine(winrarDir, "rar.exe");

            bool createSfx = ConfigService.GetValueByBool("sfx");
            string commandOptions = string.Format(
                "a -r -ag" + Constants.DATATIME_FORMAT + " -ep1 -y \"{0}\" \"{1}\"",
                targetFileName, sourcePath);
            await RunRarAsync(rarPath, commandOptions, ScaleProgress(progress, 0, createSfx ? 50 : 100));

            if (createSfx)
            {
                string commandOptions2 = string.Format(
                   "a -r -ag" + Constants.DATATIME_FORMAT + " -sfx -ep1 -y \"{0}\" \"{1}\"",
                   targetFileName, sourcePath);
                await RunRarAsync(rarPath, commandOptions2, ScaleProgress(progress, 50, 50));
            }

            progress?.Report(100);
            compressItem.LatelyDate = DateTime.Now;
            DataDao.UpdateOne(compressItem);
        }

        public static string GetTargetDirectory(CompressItem compressItem)
        {
            string folderName = SanitizeFileName(compressItem.Id + "_" + compressItem.MarkName);
            return ConfigService.GetValue("DefaultTargetPath") + "\\" + folderName;
        }

        private static string SanitizeFileName(string fileName)
        {
            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(invalidChar, '_');
            }
            return fileName;
        }

        private static IProgress<int>? ScaleProgress(IProgress<int>? progress, int offset, int range)
        {
            if (progress is null)
            {
                return null;
            }
            return new Progress<int>(percent => progress.Report(offset + (Math.Min(100, percent) * range / 100)));
        }

        private static async Task RunRarAsync(string rarPath, string arguments, IProgress<int>? progress)
        {
            ProcessStartInfo processStartInfo = new()
            {
                FileName = rarPath,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            using Process process = new()
            {
                StartInfo = processStartInfo,
                EnableRaisingEvents = true
            };

            process.OutputDataReceived += (_, e) => ReportProgress(e.Data, progress);
            process.ErrorDataReceived += (_, e) => ReportProgress(e.Data, progress);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            await process.WaitForExitAsync();
            if (process.ExitCode != 0)
            {
                throw new InvalidOperationException($"WinRAR执行失败，退出码：{process.ExitCode}");
            }
        }

        private static void ReportProgress(string? output, IProgress<int>? progress)
        {
            if (output is null || progress is null)
            {
                return;
            }

            Match match = Regex.Match(output, @"(?<percent>\d{1,3})%");
            if (!match.Success)
            {
                return;
            }

            int percent = Math.Min(100, Convert.ToInt32(match.Groups["percent"].Value));
            progress.Report(percent);
        }

    }
}
