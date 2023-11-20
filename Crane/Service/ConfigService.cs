using System.Runtime.InteropServices;
using System.Text;

namespace CTG_Control.Crane.Service
{
    /// <summary>
    /// 配置文件服务
    /// </summary>
    internal class ConfigService
    {

        private static readonly string PATH = PathService.GetApplicationPath() + "/Resources/Config/config.ini";

        // 读配置文件方法的6个参数：所在的分区（section）、 键值、
        // 初始缺省值、   StringBuilder、  参数长度上限 、配置文件路径
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern long GetPrivateProfileString(
            string section,
            string key,
            string defaultValue,
            StringBuilder retVal,
            int size,
            string filePath
        );
        //写入配置文件方法的4个参数：  所在的分区（section）、
        //键值、     参数值、       配置文件路径
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(
            string section,
            string key,
            string value,
            string filePath
        );

        /*读配置文件*/
        public static string GetValue(string section, string key)
        {
            if (!File.Exists(PATH))
            {
                return string.Empty;
            }
            StringBuilder sb = new(255);
            GetPrivateProfileString(section, key, "配置文件不存在，读取未成功!", sb, 255, PATH);
            return sb.ToString();
        }

        /// <summary>
        /// 默认为system
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            return GetValue("system", key);
        }

        /*写配置文件*/
        public static void SetValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, PATH);
        }

        public static void SetValue(string key, string value)
        {
            SetValue("system", key, value);
        }

    }
}
