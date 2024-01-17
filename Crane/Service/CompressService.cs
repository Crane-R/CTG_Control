using CTG_Control.Crane.Model.Bean;
using CTG_Control.Crane.Model.Dao;
using Microsoft.Win32;
using System.Diagnostics;

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
            string sourcePath = compressItem.SourcePath;
            string targetFileName = compressItem.TargetPath +
              "\\" + sourcePath.Substring(sourcePath.LastIndexOf("\\") + 1) + "@.rar";
            //前置检测
            if (sourcePath is null || targetFileName is null)
            {
                return;
            }

            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(WINRAR_KEY);
            string winrarPath = registryKey.GetValue("").ToString();
            registryKey.Close();
            string winrarDir = Path.GetDirectoryName(winrarPath);
            string commandOptions = string.Format(
                "a -r -agyyyyMMddHHmm -ep1 -ibck \"{0}\" \"{1}\""
                , targetFileName, sourcePath);

            ProcessStartInfo processStartInfo = new()
            {
                FileName = Path.Combine(winrarDir, "rar.exe"),
                Arguments = commandOptions,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process process = new()
            {
                StartInfo = processStartInfo
            };
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
            process.Close();

            if (ConfigService.GetValueByBool("sfx")) {
                string commandOptions2 = string.Format(
                   "a -r -agyyyyMMddHHmm -sfx -ep1 -ibck \"{0}\" \"{1}\""
                   , targetFileName, sourcePath);
                ProcessStartInfo processStartInfo2 = new()
                {
                    FileName = Path.Combine(winrarDir, "rar.exe"),
                    Arguments = commandOptions2,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process process2 = new()
                {
                    StartInfo = processStartInfo2
                };
                process2.StartInfo.CreateNoWindow = true;
                process2.Start();
                process2.WaitForExit();
                process2.Close();
            }

            //执行完成更新日期
            compressItem.LatelyDate = DateTime.Now;
            DataDao.UpdateOne(compressItem);
        }

    }
}
