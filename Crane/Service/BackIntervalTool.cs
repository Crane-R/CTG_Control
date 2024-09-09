using CTG_Control.Crane.Constant;

namespace CTG_Control.Crane.Service
{
    /// <summary>
    /// 自动备份时间转换工具
    /// </summary>
    internal class BackIntervalTool
    {
        [Obsolete("全部以小时为单位显示就行了")]
        /// <summary>
        /// 根据标准项进行hour转换并赋值给对应的组件
        /// 值得注意的时，对于类似于25hour，暂时决定将其格式化为1.1/24天
        /// 显示单位只有小时和天两个，周不是常用单位，月和年不固定因为需要日期，但这里并没有日期
        /// 显示天的话也方便计算出大概是几个月几周
        /// 单位只会显示天
        /// </summary>
        /// <param name="standardItemContent"></param>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public void StandardItem2Component(string standardItemContent, TextBox value, Label unit)
        {
            int hour = GetHourByStandardItemContent(standardItemContent);
            string tempUnit = "";
            int tempValue = -1;
            if (hour / 24 != 0)
            {
                tempUnit = "天";
                tempValue = hour / 24;
                hour %= 24;
            }
            value.Text = hour == 0 ? tempValue.ToString() : tempValue + "." + hour + "/24";
            unit.Text = tempUnit;
        }

        public int GetHourByStandardItemContent(string stardardItemContent)
        {
            return stardardItemContent switch
            {
                "慢速项" => ConfigService.GetValueByInt("slowInterval"),
                "中速项" => ConfigService.GetValueByInt("middleInterval"),
                "快速项" => ConfigService.GetValueByInt("fastInterval"),
                _ => -1,
            };
        }

    }
}
