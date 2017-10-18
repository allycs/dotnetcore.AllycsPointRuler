using System;
using System.Collections.Generic;
using System.Text;

namespace AllycsPointRuler
{
    using System;

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
        public int Amount { get; set; } = 0;

        /// <summary>
        /// 可用积分
        /// </summary>
        public int Points { get; set; } = 0;

        /// <summary>
        /// 预测时间
        /// </summary>
        public DateTime ForecastTime { get; set; } = DateTime.Now;
    }
}
