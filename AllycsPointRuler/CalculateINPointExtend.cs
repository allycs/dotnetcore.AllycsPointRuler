namespace AllycsPointRuler
{
    using System;
    using System.Collections.Generic;

    public static class CalculateINPointExtend
    {
        public static void CheckRulers(ForecastPointModel model, List<KeyValuePair<string, PointRuler>> ListOnlyRules, List<KeyValuePair<string, PointRuler>> ListMultiRules, PointRulerProductModel pointRulerProduct)
        {
            bool hasOnlyRules = false;
            INCheckOnlyRule(model, ListOnlyRules,  pointRulerProduct, ref hasOnlyRules);

            if (!hasOnlyRules)
            {
                INCheckMultipleRules(model, ListMultiRules,  pointRulerProduct);
            }
        }

        private static void INCheckMultipleRules(ForecastPointModel model, List<KeyValuePair<string, PointRuler>> ListMultiRules,  PointRulerProductModel pointRulerProduct)
        {
            string firstName = "IN_MultipleRules:";
            var thisCalResult = new CalculatePointModel { OldAmounts = model.Amount };
            foreach (var item in ListMultiRules)
            {
                var Methods = item.Key.Split('_');
                if (Methods[0].Equals("BASE"))
                {
                    BaseExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("YEAE") && model.ForecastTime.Year == Convert.ToInt32(Methods[1]))
                {
                    YEAEExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("MONTH") && model.ForecastTime.Month == Convert.ToInt32(Methods[1]))
                {
                    MONTHExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("DAY") && model.ForecastTime.Day == Convert.ToInt32(Methods[1]))
                {
                    DAYExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("WEEK") && (int)model.ForecastTime.DayOfWeek == Convert.ToInt32(Methods[1]))
                {
                    WEEKExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("HOUR") && model.ForecastTime.Hour == Convert.ToInt32(Methods[1]))
                {
                    HOURExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("MINUTE") && model.ForecastTime.Minute == Convert.ToInt32(Methods[1]))
                {
                    MINUTEExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("SECOND") && model.ForecastTime.Minute == Convert.ToInt32(Methods[1]))
                {
                    SECONDExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("YMD") && model.ForecastTime.ToString("yyyyMMdd").Equals(Methods[1]))
                {
                    YMDExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("MD") && model.ForecastTime.ToString("MMdd").Equals(Methods[1]))
                {
                    MDExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("CHINESEMD") && (new ChineseDate(model.ForecastTime).LunarMonth + new ChineseDate(model.ForecastTime).LunarDay).Trim().Equals(Methods[1]))
                {
                    //九月廿三日
                    CHINESEMDExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("MIWEEKS") && (
                            model.ForecastTime.Month.ToString().PadLeft(2, '0') +
                            CalculatePoint.GetWeekNumInMonth(model.ForecastTime).ToString().PadLeft(2, '0') +
                            ((int)model.ForecastTime.DayOfWeek).ToString().PadLeft(2, '0')
                        ).Equals(Methods[1]))
                {
                    MIWEEKSExtend(firstName, pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("EVENT"))
                {
                    EVENTExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    continue;
                }
            }
        }

        private static void INCheckOnlyRule(ForecastPointModel model, List<KeyValuePair<string, PointRuler>> ListOnlyRules, PointRulerProductModel pointRulerProduct, ref bool hasOnlyRules)
        {
            string firstName = "IN_OnlyRule:";
            var thisCalResult = new CalculatePointModel { OldAmounts = model.Amount };
            foreach (var item in ListOnlyRules)
            {
                var Methods = item.Key.Split('_');
                if (Methods[0].Equals("BASE"))
                {
                    hasOnlyRules = true;
                    BaseExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
                if (Methods[0].Equals("YEAE") && model.ForecastTime.Year == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    YEAEExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
                if (Methods[0].Equals("MONTH") && model.ForecastTime.Month == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    MONTHExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
                if (Methods[0].Equals("DAY") && model.ForecastTime.Day == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    DAYExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
                if (Methods[0].Equals("WEEK") && (int)model.ForecastTime.DayOfWeek == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    WEEKExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
                if (Methods[0].Equals("HOUR") && model.ForecastTime.Hour == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    HOURExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
                if (Methods[0].Equals("MINUTE") && model.ForecastTime.Minute == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    MINUTEExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
                if (Methods[0].Equals("SECOND") && model.ForecastTime.Minute == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    SECONDExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
                if (Methods[0].Equals("YMD") && model.ForecastTime.ToString("yyyyMMdd").Equals(Methods[1]))
                {
                    hasOnlyRules = true;
                    YMDExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
                if (Methods[0].Equals("MD") && model.ForecastTime.ToString("MMdd").Equals(Methods[1]))
                {
                    hasOnlyRules = true;
                    MDExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
                if (Methods[0].Equals("CHINESEMD") && (new ChineseDate(model.ForecastTime).LunarMonth + new ChineseDate(model.ForecastTime).LunarDay).Trim().Equals(Methods[1]))
                {
                    //九月廿三日
                    hasOnlyRules = true;
                    CHINESEMDExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
                if (Methods[0].Equals("MIWEEKS") && (
                            model.ForecastTime.Month.ToString().PadLeft(2, '0') +
                            CalculatePoint.GetWeekNumInMonth(model.ForecastTime).ToString().PadLeft(2, '0') +
                            ((int)model.ForecastTime.DayOfWeek).ToString().PadLeft(2, '0')
                        ).Equals(Methods[1]))
                {
                    hasOnlyRules = true;
                    MIWEEKSExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
                if (Methods[0].Equals("EVENT"))
                {
                    hasOnlyRules = true;
                    EVENTExtend(firstName,  pointRulerProduct, item, ref thisCalResult);
                    break;
                }
            }
        }

        private static void EVENTExtend(string firstName,  PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqEvent(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }

        private static void MIWEEKSExtend(string firstName,  PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqMIWeeks(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }

        private static void CHINESEMDExtend(string firstName, PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqChineseMD(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }

        private static void MDExtend(string firstName,  PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqMD(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }

        private static void YMDExtend(string firstName,  PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqYMD(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }

        private static void SECONDExtend(string firstName,  PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqSecond(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }

        private static void MINUTEExtend(string firstName,  PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqMinute(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }

        private static void HOURExtend(string firstName,  PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqHour(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }

        private static void WEEKExtend(string firstName,  PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqWeek(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }

        private static void DAYExtend(string firstName,  PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqDay(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }

        private static void MONTHExtend(string firstName,  PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqMonth(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }

        private static void YEAEExtend(string firstName,  PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqYear(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }

        private static void BaseExtend(string firstName,  PointRulerProductModel pointRulerProduct, KeyValuePair<string, PointRuler> item, ref CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.INEqBase(item.Value, thisCalResult);
            pointRulerProduct.CalMethods.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            pointRulerProduct.TotalProducePoints += thisCalResult.ProducePoints;
            CalculatePoint.ChangeINCalculatePointModel(thisCalResult);
        }
    }
}