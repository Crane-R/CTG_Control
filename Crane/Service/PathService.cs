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
            while (folderName.ToLower() != "bin")
            {        
                path = path.Substring(0, path.LastIndexOf("\\"));
                folderName = path.Substring(path.LastIndexOf("\\") + 1);
            }
            return path.Substring(0, path.LastIndexOf("\\") + 1);
        }


    }
}
