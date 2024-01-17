using CTG_Control.Crane.Model.Bean;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTG_Control.Crane.Service
{
    /// <summary>
    /// 删除服务
    /// </summary>
    internal class DeleteService
    {

        public DeleteService() { }

        public void AutoJudgeDelete(string path, int delayHours) {

            //获取整理该目录下的全部文件
            string[] files = Directory.GetFiles(path);
            DateTime now = DateTime.Now;
            foreach (string fileName in files)
            {
                string v = fileName.Split("-")[1].Split(".")[0];
                DateTime dt = DateTime.ParseExact(v, "yyyyMMddHHmm", CultureInfo.InvariantCulture);
                if (now.Subtract(dt).TotalHours > delayHours) { 
                    File.Delete(fileName);
                }
            }
        }

    }
}
