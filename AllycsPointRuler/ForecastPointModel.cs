namespace AllycsPointRuler
{
    using System;

    /// <summary>
    /// 用于计算积分的传入数据对象
    /// </summary>
    public class ForecastPointModel
    {
        /// <summary>
        /// 操作类型：
        /// BASE_IN:产生积分
        /// BASE_OUT:使用积分
        /// </summary>
        public string Operation { get; set; } = "BASE_IN";

        /// <summary>
        /// 规则中金额项的触发
        /// </summary>
        public Int64 Amount { get; set; } = 0;

        /// <summary>
        /// 可用积分
        /// </summary>
        public Int64 Points { get; set; } = 0;

        /// <summary>
        /// 预测时间
        /// </summary>
        public DateTime ForecastTime { get; set; } = DateTime.Now;
    }
}