using CTG_Control.Crane.Model.Bean;
using System.Text;
using Newtonsoft.Json;
using CTG_Control.Crane.Service;
using System.Xml.Serialization;

namespace CTG_Control.Crane.Model.Dao
{
    /// <summary>
    /// 数据操控
    /// </summary>
    internal class DataDao
    {

        private static string DATA_PATH = PathService.GetApplicationPath()
            + "Resources\\Data\\data.txt";

        /// <summary>
        /// 添加一个项
        /// </summary>
        /// <param name="compassItem"></param>
        public static void Add(CompressItem compressItem)
        {
            List<CompressItem> compressItems = ReadAll();
            compressItems.Add(compressItem);
            File.WriteAllText(DATA_PATH, JsonConvert.SerializeObject(compressItems));
            ConfigService.DataCountIncrement();
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

        /// <summary>
        /// 写单个
        /// </summary>
        /// <param name="compressItem"></param>
        public static void UpdateOne(CompressItem compressItem)
        {
            List<CompressItem> compressItems = ReadAll();
            CompressItem? findCompressItem = compressItems.Find(c => c.Id == compressItem.Id);
            if (findCompressItem == null) { return; }
            CompressItem.TransferObjValue(findCompressItem, compressItem);
            WriteAll(compressItems);
        }

        /// <summary>
        /// 根据集合索引删除
        /// </summary>
        /// <param name="index"></param>
        public static void DeleteByIndex(int index)
        {
            List<CompressItem> compressItems = ReadAll();
            CompressItem compressItem = compressItems[index];
            int id = compressItem.Id;
            compressItems.Remove(compressItem);
            WriteAll(compressItems);
            ConfigService.DataCountDecrement();
            if (0 == Convert.ToInt32(ConfigService.GetValue("CurrentDataCount")))
            {
                ConfigService.SetValue("NextId", "0");
                return;
            }
            if (id + 1 == Convert.ToInt32(ConfigService.GetValue("NextId")))
            {
                ConfigService.SetValue("NextId", id.ToString());
            }
        }

        public static bool DeleteById(int id)
        {
            List<CompressItem> compressItems = ReadAll();
            CompressItem? compressItem = compressItems.Find(c => c.Id == id);
            if (compressItem == null)
            {
                return false;
            }
            compressItems.Remove(compressItem);
            WriteAll(compressItems);
            ConfigService.DataCountDecrement();
            if (0 == Convert.ToInt32(ConfigService.GetValue("CurrentDataCount")))
            {
                ConfigService.SetValue("NextId", "0");
                return true;
            }
            if (id + 1 == Convert.ToInt32(ConfigService.GetValue("NextId")))
            {
                ConfigService.SetValue("NextId", id.ToString());
            }
            return true;
        }

    }
}
