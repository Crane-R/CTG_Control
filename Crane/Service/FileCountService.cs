namespace CTG_Control.Crane.Service
{
    /// <summary>
    /// 该服务用于统计执行目录下的文件数量
    /// </summary>
    internal class FileCountService
    {

        /// <summary>
        /// 不使用static，使用懒加载
        /// </summary>
        public FileCountService() { }

        /// <summary>
        /// 统计文件数量
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int FileCount(string path)
        {
            int count = 0;
            count += Directory.GetFiles(path).Length;
            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                count += FileCount(directory);
            }
            return count;
        }

        /// <summary>
        /// 统计目录大小
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public long FileLengthCount(string path)
        {
            if (File.Exists(path))
            {
                return new FileInfo(path).Length;
            }

            long allByteLength = 0;
            string[] directories = Array.Empty<string>();
            try
            {
                directories = Directory.GetDirectories(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("该路径不存在");
                return 0;
            }
            string[] files = Directory.GetFiles(path);
            string[] children = new string[directories.Length + files.Length];
            Array.Copy(directories, 0, children, 0, directories.Length);
            Array.Copy(files, 0, children, directories.Length, files.Length);

            foreach (string directory in children)
            {
                allByteLength += FileLengthCount(directory);
            }

            return allByteLength;
        }

        public string FormatFileCount(long fileLength)
        {
            double newFileLen = Convert.ToDouble(fileLength);
            string[] arr = { "B", "KB", "MB", "GB", "TB" };
            int i = 0;
            while (newFileLen >= 1024)
            {
                newFileLen /= 1024;
                i++;
            }
            return Math.Round(newFileLen, 2) + arr[i];
        }

    }
}
