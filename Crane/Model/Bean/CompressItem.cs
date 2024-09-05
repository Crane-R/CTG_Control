using Newtonsoft.Json;

namespace CTG_Control.Crane.Model.Bean
{
    /// <summary>
    /// 压缩项目类，单个对象指向一条执行项目
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    internal class CompressItem
    {
        /// <summary>
        /// 为空不转为json
        /// 源路径
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private string SourcePathValue;
        public string SourcePath
        {
            get { return SourcePathValue; }
            set { SourcePathValue = value; }
        }

        /// <summary>
        /// 目标路径
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private string TargetPathValue;
        public string TargetPath
        {
            get { return TargetPathValue; }
            set { TargetPathValue = value; }
        }

        /// <summary>
        /// 最近执行日期
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private DateTime LatelyDateValue;
        public DateTime LatelyDate
        {
            get { return LatelyDateValue; }
            set { LatelyDateValue = value; }
        }

        /// <summary>
        /// id标识
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private int IdValue;
        public int Id
        {
            get { return IdValue; }
            set { IdValue = value; }
        }

        /// <summary>
        /// 标识名
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private string MarkNameValue;
        public string MarkName
        {
            get { return MarkNameValue; }
            set { MarkNameValue = value; }
        }

        /// <summary>
        /// 是否自动备份
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool IsAutoBackValue;
        public bool IsAutoBack
        {
            get { return IsAutoBackValue; }
            set { IsAutoBackValue = value; }
        }


        public CompressItem()
        {
            MarkNameValue = string.Empty;
            SourcePathValue = string.Empty;
            TargetPathValue = string.Empty;
        }
        public CompressItem(int Id, string MarkName, string SourcePath, string TargetPath, DateTime LatelyDate, bool isAutoBack)
        {
            SourcePathValue = SourcePath;
            TargetPathValue = TargetPath;
            LatelyDateValue = LatelyDate;
            IdValue = Id;
            MarkNameValue = MarkName;
            IsAutoBack = isAutoBack;
        }

        public static void TransferObjValue(CompressItem TargetObj, CompressItem OriginObj)
        {
            TargetObj.Id = OriginObj.Id;
            TargetObj.SourcePath = OriginObj.SourcePath;
            TargetObj.TargetPath = OriginObj.TargetPath;
            TargetObj.LatelyDate = OriginObj.LatelyDate;
            TargetObj.MarkName = OriginObj.MarkName;
            TargetObj.IsAutoBack = OriginObj.IsAutoBack;
        }

    }
}
