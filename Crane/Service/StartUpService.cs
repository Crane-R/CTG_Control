using CTG_Control.Crane.Constant;
using Microsoft.Win32;

namespace CTG_Control.Crane.Service
{
    /// <summary>
    /// 开机自启服务
    /// </summary>
    internal class StartUpService
    {
        private string softwareName = Constants.PROGRAM_VERSION;

        private RegistryKey registryKey;

        public StartUpService()
        {
            registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }


        public void OpenStartUp()
        {
            try
            {
                registryKey.SetValue(softwareName, Application.ExecutablePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CloseStartUp()
        {
            try
            {
                registryKey.DeleteValue(softwareName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
