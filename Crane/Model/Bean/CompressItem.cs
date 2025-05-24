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
        private string _SourcePath;
        public string SourcePath
        {
            get { return _SourcePath; }
            set { _SourcePath = value; }
        }

        /// <summary>
        /// 最近执行日期
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private DateTime _LatelyDate;
        public DateTime LatelyDate
        {
            get { return _LatelyDate; }
            set { _LatelyDate = value; }
        }

        /// <summary>
        /// id标识
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /// <summary>
        /// 标识名
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private string _MarkName;
        public string MarkName
        {
            get { return _MarkName; }
            set { _MarkName = value; }
        }

        /// <summary>
        /// 是否自动备份
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool _IsAutoBack;
        public bool IsAutoBack
        {
            get { return _IsAutoBack; }
            set { _IsAutoBack = value; }
        }

        /// <summary>
        /// 自动备份时间间隔
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private int _BackInterval;
        public int BackInterval
        {
            get { return _BackInterval; }
            set { _BackInterval = value; }
        }

        /// <summary>
        /// 上次备份用时，单位始终是分钟
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private double _LastBackPast;
        public double LastBackPast
        {
            get { return _LastBackPast; }
            set { _LastBackPast = value; }
        }

        public CompressItem()
        {
            _MarkName = string.Empty;
            _SourcePath = string.Empty;
        }
        public CompressItem(int id, string markName, string sourcePath, 
            DateTime latelyDate, bool isAutoBack, int backInterval, int lastBackPast)
        {
            _SourcePath = sourcePath;
            _LatelyDate = latelyDate;
            _Id = id;
            _MarkName = markName;
            _IsAutoBack = isAutoBack;
            _BackInterval = backInterval;
            _LastBackPast = lastBackPast;
        }

        public static void TransferObjValue(CompressItem TargetObj, CompressItem OriginObj)
        {
            TargetObj._Id = OriginObj._Id;
            TargetObj._SourcePath = OriginObj._SourcePath;
            TargetObj._LatelyDate = OriginObj._LatelyDate;
            TargetObj._MarkName = OriginObj._MarkName;
            TargetObj._IsAutoBack = OriginObj._IsAutoBack;
            TargetObj._BackInterval = OriginObj._BackInterval;
            TargetObj._LastBackPast = OriginObj._LastBackPast;
        }

    }
}
