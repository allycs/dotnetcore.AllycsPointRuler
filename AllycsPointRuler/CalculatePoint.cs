namespace AllycsPointRuler
{
    using System;

    public static class CalculatePoint
    {
        /// <summary>
        /// 判断当前日期时本月的第几周
        /// </summary>
        /// <param name="daytime"></param>
        /// <returns></returns>
        public static int GetWeekNumInMonth(DateTime daytime)
        {
            int dayInMonth = daytime.Day;
            //本月第一天
            DateTime firstDay = daytime.AddDays(1 - daytime.Day);
            //本月第一天是周几
            int weekday = (int)firstDay.DayOfWeek == 0 ? 7 : (int)firstDay.DayOfWeek;
            //本月第一周有几天
            int firstWeekEndDay = 7 - (weekday - 1);
            //当前日期和第一周之差
            int diffday = dayInMonth - firstWeekEndDay;
            diffday = diffday > 0 ? diffday : 1;
            //当前是第几周,如果整除7就减一天
            int WeekNumInMonth = ((diffday % 7) == 0
             ? (diffday / 7 - 1)
             : (diffday / 7)) + 1 + (dayInMonth > firstWeekEndDay ? 1 : 0);
            return WeekNumInMonth;
        }

        #region INPoint操作

        public static void ChangeINCalculatePointModel(CalculatePointModel thisCalResult)
        {
            thisCalResult.OldPoints = thisCalResult.NewPoints;
            thisCalResult.NewAmounts = 0;
            thisCalResult.NewPoints = 0;
            thisCalResult.ProducePoints = 0;
            thisCalResult.ProduceAmounts = 0;
        }

        public static CalculatePointModel INEqBase(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel INEqEvent(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel INEqMIWeeks(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel INEqChineseMD(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel INEqMD(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel INEqYMD(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel INEqSecond(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel INEqMinute(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel INEqHour(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel INEqWeek(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel INEqDay(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel INEqMonth(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel INEqYear(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                INPoint0(ruler.Amount, ruler.Multiple, calData);
            else
                INPointNo0(ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        private static CalculatePointModel INPoint0(Int64 amount, Int64 multiple, CalculatePointModel calData)
        {
            if (amount == 0 && multiple != 0)
            {
                //翻倍沿用之前运算符号
                calData.NewAmounts = calData.OldAmounts;
                calData.NewPoints = calData.OldPoints * multiple;
                calData.ProducePoints = calData.NewPoints - calData.OldPoints;
                calData.ProduceAmounts = 0;
                return calData;
            }
            calData.NewAmounts = calData.OldAmounts;
            calData.NewPoints = calData.OldPoints;
            calData.ProducePoints = 0;
            calData.ProduceAmounts = 0;
            return calData;
        }

        private static CalculatePointModel INPointNo0(bool plusOrMinus, Int64 point, Int64 amount, int multiple, CalculatePointModel calData)
        {
            if (amount == 0 && multiple != 0)
            {
                calData.NewAmounts = calData.OldAmounts;
                calData.ProduceAmounts = 0;
                calData.ProducePoints = point * multiple;
                if (!plusOrMinus)
                    calData.ProducePoints = -calData.ProducePoints;
                calData.NewPoints = calData.OldPoints + calData.ProducePoints;

                return calData;
            }
            if (amount == 0 && multiple == 0)
            {
                calData.NewAmounts = calData.OldAmounts;
                calData.ProduceAmounts = 0;
                calData.ProducePoints = point;
                if (plusOrMinus)
                    calData.NewPoints = calData.OldPoints + calData.ProducePoints;
                else
                {
                    calData.ProducePoints = -point;
                    calData.NewPoints = calData.OldPoints + calData.ProducePoints;
                }
                return calData;
            }
            if (amount != 0 && multiple == 0)
            {
                var count = calData.OldAmounts / amount;
                calData.ProduceAmounts = amount * count;
                calData.NewAmounts = calData.OldAmounts - (calData.ProduceAmounts);
                calData.ProducePoints = point * count;
                if (plusOrMinus)
                    calData.NewPoints = calData.OldPoints + calData.ProducePoints;
                else
                {
                    calData.ProducePoints = -calData.ProducePoints;
                    calData.NewPoints = calData.OldPoints + calData.ProducePoints;
                }
                return calData;
            }
            if (amount != 0 && multiple != 0)
            {
                var count = calData.OldAmounts / amount;
                calData.ProduceAmounts = amount * count;
                calData.NewAmounts = calData.OldAmounts - (calData.ProduceAmounts);
                calData.ProducePoints = point * count * multiple;
                if (plusOrMinus)
                    calData.NewPoints = calData.OldPoints + calData.ProducePoints;
                else
                {
                    calData.ProducePoints = -calData.ProducePoints;
                    calData.NewPoints = calData.OldPoints + calData.ProducePoints;
                }
                return calData;
            }
            return calData;
        }

        #endregion INPoint操作

        #region OUTPoint操作

        public static void ChangeOUTCalculatePointModel(CalculatePointModel thisCalResult)
        {
            thisCalResult.OldPoints = thisCalResult.NewPoints > 0 ? thisCalResult.NewPoints : 0;
            thisCalResult.OldAmounts = thisCalResult.NewAmounts > 0 ? thisCalResult.NewAmounts : 0;
            thisCalResult.NewAmounts = 0;
            thisCalResult.NewPoints = 0;
            thisCalResult.ProducePoints = 0;
            thisCalResult.ProduceAmounts = 0;
        }

        public static CalculatePointModel OUTEqBase(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel OUTEqEvent(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel OUTEqMIWeeks(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel OUTEqChineseMD(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel OUTEqMD(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel OUTEqYMD(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel OUTEqSecond(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel OUTEqMinute(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel OUTEqHour(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel OUTEqWeek(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel OUTEqDay(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel OUTEqMonth(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        public static CalculatePointModel OUTEqYear(PointRuler ruler, CalculatePointModel calData)
        {
            if (ruler.Point == 0)
                OUTAmount0(ruler.PlusOrMinus, ruler.Amount, ruler.Multiple, calData);
            else
                OUTAmountNo0(ruler.Deduction, ruler.PlusOrMinus, ruler.Point, ruler.Amount, ruler.Multiple, calData);
            return calData;
        }

        private static CalculatePointModel OUTAmount0(bool plusOrMinus, Int64 point, Int64 multiple, CalculatePointModel calData)
        {
            if (point != 0 && multiple != 0)
            {
                calData.NewAmounts = calData.OldAmounts;
                calData.ProducePoints = point * multiple;
                if (!plusOrMinus)
                    calData.ProducePoints = -calData.ProducePoints;
                calData.NewPoints = calData.OldPoints + calData.ProducePoints;
                calData.ProduceAmounts = 0;
                return calData;
            }
            if (point != 0 && multiple == 0)
            {
                calData.NewAmounts = calData.OldAmounts;
                calData.ProducePoints = point;
                if (!plusOrMinus)
                    calData.ProducePoints = -calData.ProducePoints;
                calData.NewPoints = calData.OldPoints + calData.ProducePoints;
                calData.ProduceAmounts = 0;
                return calData;
            }

            calData.NewPoints = calData.OldPoints;
            calData.NewAmounts = calData.OldAmounts;
            calData.ProducePoints = 0;
            calData.ProduceAmounts = 0;
            return calData;
        }

        private static CalculatePointModel OUTAmountNo0(bool deduction, bool plusOrMinus, Int64 point, Int64 amount, int multiple, CalculatePointModel calData)
        {
            if (point == 0 && multiple != 0)
            {
                calData.NewPoints = calData.OldPoints;
                calData.ProducePoints = 0;
                calData.ProduceAmounts = amount * multiple;
                calData.NewAmounts = calData.OldAmounts - calData.ProduceAmounts;
                if (!deduction && calData.NewAmounts <= 0)
                {
                    calData.ProduceAmounts = 0;
                    calData.NewAmounts = calData.OldAmounts;
                }
                return calData;
            }
            if (point == 0 && multiple == 0)
            {
                calData.NewPoints = calData.OldPoints;
                calData.ProducePoints = 0;
                calData.ProduceAmounts = amount;
                calData.NewAmounts = calData.OldAmounts - calData.ProduceAmounts;
                if (!deduction && calData.NewAmounts <= 0)
                {
                    calData.ProduceAmounts = 0;
                    calData.NewAmounts = calData.OldAmounts;
                }
                return calData;
            }
            if (point != 0 && multiple == 0)
            {
                if (calData.OldPoints == 0)
                    return calData;
                var count = calData.OldPoints / point;
                if (calData.OldAmounts > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (!deduction && calData.OldAmounts - calData.ProduceAmounts - amount <= 0)
                            break;
                        calData.ProduceAmounts += amount;
                        calData.ProducePoints += point;
                        if (!plusOrMinus)
                            calData.ProducePoints -= point;
                        if (calData.OldAmounts - calData.ProduceAmounts <= 0)
                            break;
                    }
                }

                if (!plusOrMinus)
                    calData.ProducePoints = -calData.ProducePoints;
                calData.NewPoints = calData.OldPoints + calData.ProducePoints;
                calData.NewAmounts = calData.OldAmounts - calData.ProduceAmounts;
                return calData;
            }

            if (point != 0 && multiple != 0)
            {
                if (calData.OldPoints == 0)
                    return calData;
                var count = calData.OldPoints / point;
                if (calData.OldAmounts > 0)
                    for (int i = 0; i < count; i++)
                    {
                        calData.ProduceAmounts += amount * multiple;
                        calData.ProducePoints += point;
                        if (!plusOrMinus)
                            calData.ProducePoints -= point;
                        if (calData.OldAmounts - calData.ProduceAmounts <= 0)
                            break;
                    }
                if (!plusOrMinus)
                    calData.ProducePoints = -calData.ProducePoints;
                calData.NewPoints = calData.OldPoints + calData.ProducePoints;
                calData.NewAmounts = calData.OldAmounts - calData.ProduceAmounts;
                return calData;
            }
            return calData;
        }

        #endregion OUTPoint操作
    }
}