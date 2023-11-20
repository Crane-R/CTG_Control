﻿using Microsoft.Win32;
using System.Diagnostics;

namespace CTG_Control.Crane.Service
{
    /// <summary>
    /// 压缩服务
    /// </summary>
    internal class CompressService
    {

        private CompressService() { }

        /// <summary>
        /// 检查是否安装winrar
        /// </summary>
        /// <returns></returns>
        public static bool NotExistsWinRar()
        {
            string result = string.Empty;

            string key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe";
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(key);
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
            string regKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe";
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(regKey);
            string winrarPath = registryKey.GetValue("").ToString();
            registryKey.Close();
            string winrarDir = System.IO.Path.GetDirectoryName(winrarPath);
            String commandOptions = string.Format("x {0} {1} -y", rarFileName, saveDir);

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
        /// 将目录和文件压缩为rar格式并保存到指定的目录
        /// </summary>
        /// <param name="soruceDir">要压缩的文件夹目录</param>
        /// <param name="rarFileName">压缩后的rar保存路径</param>
        public static void CompressRar(string soruceDir, string rarFileName)
        {
            string regKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe";
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(regKey);
            string winrarPath = registryKey.GetValue("").ToString();
            registryKey.Close();
            string winrarDir = Path.GetDirectoryName(winrarPath);
            string commandOptions = string.Format(
                "a -r -agYYMMDDHHMM -ep1 -ibck \"{0}\" \"{1}\""
                , rarFileName, soruceDir);

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
            process.Start();
            process.WaitForExit();
            process.Close();
        }

    }
}
