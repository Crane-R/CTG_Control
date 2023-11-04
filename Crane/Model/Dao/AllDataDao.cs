using CTG_Control.Crane.Model.Bean;
using System.Text;
using Newtonsoft.Json;
using CTG_Control.Crane.Model.Service;

namespace CTG_Control.Crane.Model.Dao
{
    /// <summary>
    /// 数据操控
    /// </summary>
    internal class AllDataDao
    {

        private static string DATA_PATH = PathService.GetApplicationPath()
            + "Crane\\Model\\Data\\allData.txt";

        public static void Write(CompassItem compassItem)
        {
            List<CompassItem> compassItems = ReadAll();
            compassItems.Add(compassItem);
            File.WriteAllText(DATA_PATH, JsonConvert.SerializeObject(compassItems));
        }

        public static List<CompassItem> ReadAll()
        {
            List<CompassItem>? compassItems = JsonConvert.DeserializeObject<List<CompassItem>>(File.ReadAllText(DATA_PATH, Encoding.UTF8));
            return compassItems == null ? new List<CompassItem> { } : compassItems;
        }

    }
}
