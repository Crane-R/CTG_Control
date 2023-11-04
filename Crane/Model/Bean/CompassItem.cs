using Newtonsoft.Json;

namespace CTG_Control.Crane.Model.Bean
{
    /// <summary>
    /// 压缩项目类，单个对象指向一条执行项目
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    internal class CompassItem
    {

        public CompassItem(string SourcePath, string TargetPath)
        {
            SourcePathValue = SourcePath;
            TargetPathValue = TargetPath;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private string SourcePathValue;
        public string SourcePath
        {
            get
            {
                return SourcePathValue;
            }
            set
            {
                SourcePathValue = value;
            }
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private string TargetPathValue;
        public string TargetPath
        {
            get
            {
                return TargetPathValue;
            }
            set
            {
                TargetPathValue = value;
            }
        }
    }
}
