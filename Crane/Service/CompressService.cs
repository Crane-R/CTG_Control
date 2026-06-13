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
        private static Process? currentCompressProcess;
        private static readonly object processLock = new();

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

        public static async Task CompressRarAsync(CompressItem compressItem, IProgress<int>? progress, string? remark = null)
        {
            string sourcePath = compressItem.SourcePath;
            if (sourcePath is null)
            {
                return;
            }

            string targetPath = GetTargetDirectory(compressItem);
            Directory.CreateDirectory(targetPath);
            string remarkPart = string.IsNullOrWhiteSpace(remark) ? "" : "_" + SanitizeFileName(remark.Trim());
            string targetFileName = targetPath + "\\" + compressItem.Id + "_" + compressItem.MarkName + remarkPart + "@.rar";

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
            RecordCompressSize(compressItem);
            DataDao.UpdateOne(compressItem);
        }

        private static void RecordCompressSize(CompressItem compressItem)
        {
            try
            {
                FileCountService fileCountService = new();
                compressItem.BeforeSize = fileCountService.FileLengthCount(compressItem.SourcePath);

                string targetDir = GetTargetDirectory(compressItem);
                if (Directory.Exists(targetDir))
                {
                    var rarFiles = Directory.GetFiles(targetDir, "*.rar")
                        .Select(f => new FileInfo(f))
                        .OrderByDescending(f => f.LastWriteTime)
                        .ToList();
                    if (rarFiles.Count > 0)
                    {
                        compressItem.AfterSize = rarFiles[0].Length;
                        if (compressItem.BeforeSize > 0)
                        {
                            compressItem.CompressionRatio = Math.Round(
                                (double)compressItem.AfterSize / compressItem.BeforeSize * 100, 2);
                        }
                    }
                }
            }
            catch
            {
                // 计算大小失败不影响主流程
            }
        }

        public static string GetTargetDirectory(CompressItem compressItem)
        {
            string folderName = SanitizeFileName(compressItem.Id + "_" + compressItem.MarkName);
            return ConfigService.GetLocalTargetPath() + "\\" + folderName;
        }

        public static string GetCloudTargetDirectory(CompressItem compressItem)
        {
            string folderName = SanitizeFileName(compressItem.Id + "_" + compressItem.MarkName);
            return ConfigService.GetCloudTargetPath() + "\\" + folderName;
        }

        public static string UploadAllLatestToCloud()
        {
            string cloudPath = ConfigService.GetCloudTargetPath();
            string localPath = ConfigService.GetLocalTargetPath();
            if (string.IsNullOrEmpty(cloudPath))
            {
                return "请先设置云端备份库路径";
            }
            if (string.IsNullOrEmpty(localPath))
            {
                return "请先设置本地备份库路径";
            }

            List<CompressItem> items = DataDao.ReadAll();
            int successCount = 0;
            int failCount = 0;

            foreach (CompressItem item in items)
            {
                string folderName = SanitizeFileName(item.Id + "_" + item.MarkName);
                string localDir = localPath + "\\" + folderName;
                string cloudDir = cloudPath + "\\" + folderName;

                if (!Directory.Exists(localDir))
                {
                    continue;
                }

                FileInfo? latestFile = Directory.GetFiles(localDir, "*.rar")
                    .Select(f => new FileInfo(f))
                    .OrderByDescending(f => f.LastWriteTime)
                    .FirstOrDefault();

                if (latestFile == null)
                {
                    continue;
                }

                try
                {
                    Directory.CreateDirectory(cloudDir);
                    string destFile = Path.Combine(cloudDir, latestFile.Name);
                    File.Copy(latestFile.FullName, destFile, true);
                    successCount++;
                }
                catch
                {
                    failCount++;
                }
            }

            return $"上传完成，成功：{successCount}，失败：{failCount}";
        }

        public static void ForceStopCompress()
        {
            lock (processLock)
            {
                if (currentCompressProcess is not null && !currentCompressProcess.HasExited)
                {
                    currentCompressProcess.Kill(true);
                }
            }
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
            lock (processLock)
            {
                currentCompressProcess = process;
            }
            try
            {
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                await process.WaitForExitAsync();
                if (process.ExitCode != 0)
                {
                    throw new InvalidOperationException($"WinRAR执行失败，退出码：{process.ExitCode}");
                }
            }
            finally
            {
                lock (processLock)
                {
                    if (ReferenceEquals(currentCompressProcess, process))
                    {
                        currentCompressProcess = null;
                    }
                }
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
