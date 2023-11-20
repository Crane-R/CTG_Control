using Newtonsoft.Json;

namespace CTG_Control.Crane.Model.Bean
{
    /// <summary>
    /// 压缩项目类，单个对象指向一条执行项目
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    internal class CompressItem
    {

        public CompressItem()
        {
            SourcePathValue = string.Empty;
            TargetPathValue = string.Empty;
        }
        public CompressItem(string SourcePath, string TargetPath, DateTime LatelyDate, int Id)
        {
            SourcePathValue = SourcePath;
            TargetPathValue = TargetPath;
            LatelyDateValue = LatelyDate;
            IdValue = Id;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private string SourcePathValue;
        public string SourcePath
        {
            get { return SourcePathValue; }
            set { SourcePathValue = value; }
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private string TargetPathValue;
        public string TargetPath
        {
            get { return TargetPathValue; }
            set { TargetPathValue = value; }
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private DateTime LatelyDateValue;
        public DateTime LatelyDate
        {
            get { return LatelyDateValue; }
            set { LatelyDateValue = value; }
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private int IdValue;
        public int Id
        {
            get { return IdValue; }
            set { IdValue = value; }
        }

        public static void TransferObjValue(CompressItem TargetObj, CompressItem OriginObj)
        {
            TargetObj.Id = OriginObj.Id;
            TargetObj.SourcePath = OriginObj.SourcePath;
            TargetObj.TargetPath = OriginObj.TargetPath;
            TargetObj.LatelyDate = OriginObj.LatelyDate;
        }

    }
}
