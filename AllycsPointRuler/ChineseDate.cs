using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AllycsPointRuler
{    /// <summary>
     /// 农历日期
     /// </summary>
    public class ChineseDate
    {
        #region 静态属性

        /// <summary>
        /// 获得当前时间的农历日期实例
        /// </summary>
        /// <returns></returns>
        public static ChineseDate Now => new ChineseDate();

        #endregion 静态属性

        #region 公用方法

        /// <summary>
        /// 返回农历日期的字符串形式
        /// </summary>
        /// <returns>仅包含农历的年月日</returns>
        public override string ToString()
        {
            return LunarYear + LunarMonth + LunarDay;
        }

        #endregion 公用方法

        #region 私有变量

        /// <summary>
        /// 要处理的日期
        /// </summary>
        private readonly DateTime _dateTime;

        /// <summary>
        /// 中国农历对象
        /// </summary>
        private readonly ChineseLunisolarCalendar _lunar = new ChineseLunisolarCalendar();

        #endregion 私有变量

        #region 构造函数

        /// <param name="sDate">日期时间格式的字符串</param>
        public ChineseDate(string sDate)
        {
            _dateTime = new DateTime();
            var bRet = DateTime.TryParse(sDate, out _dateTime);
            if (!bRet)
                throw new ArgumentOutOfRangeException(nameof(sDate), "不是合法的DateTime格式");
        }

        /// <param name="dt">日期时间</param>
        public ChineseDate(DateTime dt)
        {
            _dateTime = dt;
        }

        /// <summary>
        /// 当前的农历日期
        /// </summary>
        public ChineseDate()
        {
            _dateTime = DateTime.Now;
        }

        #endregion 构造函数

        #region 农历属性

        /// <summary>
        /// 生肖
        /// </summary>
        public string LunarAnimal
        {
            get
            {
                const string szText3 = "鼠牛虎兔龙蛇马羊猴鸡狗猪";
                var iYear = _lunar.GetYear(_dateTime);
                var result = szText3.Substring((iYear - 4) % 12, 1);

                return result;
            }
        }

        /// <summary>
        /// 农历年
        /// </summary>
        public string LunarYear
        {
            get
            {
                const string szText1 = "甲乙丙丁戊己庚辛壬癸";
                const string szText2 = "子丑寅卯辰巳午未申酉戌亥";
                const string szText3 = "鼠牛虎兔龙蛇马羊猴鸡狗猪";
                var iYear = _lunar.GetYear(_dateTime);
                var strYear = szText1.Substring((iYear - 4) % 10, 1);
                strYear = strYear + szText2.Substring((iYear - 4) % 12, 1);
                strYear = strYear + " ";
                strYear = strYear + szText3.Substring((iYear - 4) % 12, 1);
                strYear = strYear + "年";
                return strYear;
            }
        }

        /// <summary>
        /// 农历月
        /// </summary>
        public string LunarMonth
        {
            get
            {
                var iMonth = _lunar.GetMonth(_dateTime);
                const string szText = "正二三四五六七八九十";
                string strMonth;
                if (iMonth <= 10)
                {
                    strMonth = "";
                    strMonth = strMonth + szText.Substring(iMonth - 1, 1);
                    strMonth = strMonth + "月";
                    return strMonth;
                }
                strMonth = iMonth == 11 ? "十一" : "腊";
                return strMonth + "月";
            }
        }

        /// <summary>
        /// 农历日
        /// </summary>
        public string LunarDay
        {
            get
            {
                var iDay = _lunar.GetDayOfMonth(_dateTime);

                const string szText1 = "初十廿三";
                const string szText2 = "一二三四五六七八九十";
                string strDay;
                if (iDay != 20 && iDay != 30)
                {
                    strDay = szText1.Substring((iDay - 1) / 10, 1);
                    strDay = strDay + szText2.Substring((iDay - 1) % 10, 1);
                }
                else
                {
                    strDay = szText1.Substring(iDay / 10 * 2 + 1, 2);
                    strDay = strDay + "十";
                }
                return strDay + "日";
            }
        }

        #endregion 农历属性
    }
}
