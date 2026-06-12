using CTG_Control.Crane.Constant;
using System.Globalization;

namespace CTG_Control.Crane.Service
{
    /// <summary>
    /// 删除服务
    /// </summary>
    internal class DeleteService
    {

        public DeleteService() { }

        public void AutoJudgeDelete(string path, int delayHours)
        {

            //获取整理该目录下的全部文件
            string[] files = Array.Empty<string>();
            try
            {
                files = Directory.GetFiles(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            DateTime now = DateTime.Now;
            foreach (string fileName in files)
            {
                string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                int timeSeparatorIndex = nameWithoutExtension.LastIndexOf("@");
                if (timeSeparatorIndex < 0)
                {
                    continue;
                }

                string v = nameWithoutExtension.Substring(timeSeparatorIndex + 1);
                if (!DateTime.TryParseExact(v, Constants.DATATIME_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    continue;
                }

                if (now.Subtract(dt).TotalHours > delayHours)
                {
                    File.Delete(fileName);
                }
            }
        }

    }
}
