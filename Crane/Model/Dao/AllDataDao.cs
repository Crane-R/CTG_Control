using CTG_Control.Crane.Model.Bean;
using System.Text;
using Newtonsoft.Json;
using CTG_Control.Crane.Service;

namespace CTG_Control.Crane.Model.Dao
{
    /// <summary>
    /// 数据操控
    /// </summary>
    internal class AllDataDao
    {

        private static string DATA_PATH = PathService.GetApplicationPath()
            + "Resources\\Data\\allData.txt";

        /// <summary>
        /// 添加一个项
        /// </summary>
        /// <param name="compassItem"></param>
        public static void Add(CompressItem compressItem)
        {
            List<CompressItem> compressItems = ReadAll();
            compressItems.Add(compressItem);
            File.WriteAllText(DATA_PATH, JsonConvert.SerializeObject(compressItems));
        }

        /// <summary>
        /// 读取全部项
        /// </summary>
        /// <returns></returns>
        public static List<CompressItem> ReadAll()
        {
            List<CompressItem>? compassItems = JsonConvert.DeserializeObject<List<CompressItem>>(File.ReadAllText(DATA_PATH, Encoding.UTF8));
            return compassItems == null ? new List<CompressItem> { } : compassItems;
        }

        /// <summary>
        /// 覆盖全部
        /// </summary>
        public static void WriteAll(List<CompressItem> compressItems)
        {
            File.WriteAllText(DATA_PATH, JsonConvert.SerializeObject(compressItems));
        }

    }
}
