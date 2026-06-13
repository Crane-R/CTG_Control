using CTG_Control.Crane.Service;

namespace CTG_Control.Crane.Constant
{
    internal static class Constants
    {
        public const string ADD_SOURCE_PATH_BLANK = "点击选择源路径";

        public const string ADD_TARGET_PATH_BLANK = "点击选择目标路径";

        public const string MARK_NAME_BLANK = "输入标识名";

        public const string PROGRAM_NAME_CN = "压缩备份中心";

        public const string VERSION = "v3.2.2";

        public const string DATATIME_FORMAT = "yyyyMMddHHmmss";

        public const string PUBLISH_DATE = "2026-06-13";

        public static string PROGRAM_VERSION
        {
            get
            {
                string suffix = IsWithin30DaysOfPublish() ? "-rc" : "";
                return "CTG_Control " + VERSION + suffix;
            }
        }

        private static bool IsWithin30DaysOfPublish()
        {
            if (!DateTime.TryParseExact(PUBLISH_DATE, "yyyy-MM-dd", null,
                    System.Globalization.DateTimeStyles.None, out DateTime publishDate))
            {
                return false;
            }
            return (DateTime.Now - publishDate).TotalDays <= 30;
        }

    }
}
