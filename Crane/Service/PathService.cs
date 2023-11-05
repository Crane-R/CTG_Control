namespace CTG_Control.Crane.Service
{
    internal class PathService
    {

        public static string GetApplicationPath()
        {
            string path = Application.StartupPath;
            //如果程序路径不包含bin说明是正式环境，直接跳
            if (!path.Contains("\\bin\\"))
            {
                return path;
            }
            string folderName = string.Empty;
            Console.WriteLine("获取到的Application.StartupPath：" + path);
            while (folderName.ToLower() != "bin")
            {
                Console.WriteLine("获取到的Application.StartupPath：" + path);
                path = path.Substring(0, path.LastIndexOf("\\"));
                folderName = path.Substring(path.LastIndexOf("\\") + 1);
            }
            return path.Substring(0, path.LastIndexOf("\\") + 1);
        }


    }
}
