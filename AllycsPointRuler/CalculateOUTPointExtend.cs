using System;
using System.Collections.Generic;
using System.Text;

namespace AllycsPointRuler
{
    using System;
    using System.Collections.Generic;

    public static class CalculateOUTPointExtend
    {
        public static PointRulerProductModel CheckRulers(ForecastPointModel model, List<KeyValuePair<string, PointRuler>> ListOnlyRules, List<KeyValuePair<string, PointRuler>> ListMultiRules, List<CalMethodModel> calMethodModel)
        {
            var result = new PointRulerProductModel();
            bool hasOnlyRules = false;
            result = OUTCheckOnlyRule(model, ListOnlyRules, calMethodModel, ref hasOnlyRules);

            if (!hasOnlyRules)
            {
                result = OUTCheckMultipleRules(model, ListMultiRules, calMethodModel);
            }
            return result;
        }

        private static PointRulerProductModel OUTCheckMultipleRules(ForecastPointModel model, List<KeyValuePair<string, PointRuler>> ListMultiRules, List<CalMethodModel> calMethodModel)
        {
            var result = new PointRulerProductModel();
            const string firstName = "OUT_MultipleRules:";
            var thisCalResult = new CalculatePointModel { OldAmounts = model.Amount, OldPoints = model.Points };

            foreach (var item in ListMultiRules)
            {
                var Methods = item.Key.Split('_');
                if (Methods[0].Equals("BASE"))
                {
                    BaseExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("YEAE") && model.ForecastTime.Year == Convert.ToInt32(Methods[1]))
                {
                    YEAEExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("MONTH") && model.ForecastTime.Month == Convert.ToInt32(Methods[1]))
                {
                    MONTHExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("DAY") && model.ForecastTime.Day == Convert.ToInt32(Methods[1]))
                {
                    DAYExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("WEEK") && (int)model.ForecastTime.DayOfWeek == Convert.ToInt32(Methods[1]))
                {
                    WEEKExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("HOUR") && model.ForecastTime.Hour == Convert.ToInt32(Methods[1]))
                {
                    HOURExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("MINUTE") && model.ForecastTime.Minute == Convert.ToInt32(Methods[1]))
                {
                    MINUTEExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("SECOND") && model.ForecastTime.Minute == Convert.ToInt32(Methods[1]))
                {
                    SECONDExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("YMD") && model.ForecastTime.ToString("yyyyMMdd").Equals(Methods[1]))
                {
                    YMDExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("MD") && model.ForecastTime.ToString("MMdd").Equals(Methods[1]))
                {
                    MDExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("CHINESEMD") && (new ChineseDate(model.ForecastTime).LunarMonth + new ChineseDate(model.ForecastTime).LunarDay).Trim().Equals(Methods[1]))
                {
                    //九月廿三日
                    CHINESEMDExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("MIWEEKS") && (
                            model.ForecastTime.Month.ToString().PadLeft(2, '0') +
                            CalculatePoint.GetWeekNumInMonth(model.ForecastTime).ToString().PadLeft(2, '0') +
                            ((int)model.ForecastTime.DayOfWeek).ToString().PadLeft(2, '0')
                        ).Equals(Methods[1]))
                {
                    MIWEEKSExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
                if (Methods[0].Equals("EVENT"))
                {
                    EVENTExtend(firstName, calMethodModel, result, item, thisCalResult);
                    continue;
                }
            }

            return result;
        }

        private static PointRulerProductModel OUTCheckOnlyRule(ForecastPointModel model, List<KeyValuePair<string, PointRuler>> ListOnlyRules, List<CalMethodModel> calMethodModel, ref bool hasOnlyRules)
        {
            var result = new PointRulerProductModel();
            const string firstName = "OUT_OnlyRule:"; var thisCalResult = new CalculatePointModel { OldAmounts = model.Amount, OldPoints = model.Points };

            foreach (var item in ListOnlyRules)
            {
                var Methods = item.Key.Split('_');
                if (Methods[0].Equals("BASE"))
                {
                    hasOnlyRules = true;
                    BaseExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
                if (Methods[0].Equals("YEAE") && model.ForecastTime.Year == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    YEAEExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
                if (Methods[0].Equals("MONTH") && model.ForecastTime.Month == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    MONTHExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
                if (Methods[0].Equals("DAY") && model.ForecastTime.Day == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    DAYExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
                if (Methods[0].Equals("WEEK") && (int)model.ForecastTime.DayOfWeek == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    WEEKExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
                if (Methods[0].Equals("HOUR") && model.ForecastTime.Hour == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    HOURExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
                if (Methods[0].Equals("MINUTE") && model.ForecastTime.Minute == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    MINUTEExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
                if (Methods[0].Equals("SECOND") && model.ForecastTime.Minute == Convert.ToInt32(Methods[1]))
                {
                    hasOnlyRules = true;
                    SECONDExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
                if (Methods[0].Equals("YMD") && model.ForecastTime.ToString("yyyyMMdd").Equals(Methods[1]))
                {
                    hasOnlyRules = true;
                    YMDExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
                if (Methods[0].Equals("MD") && model.ForecastTime.ToString("MMdd").Equals(Methods[1]))
                {
                    hasOnlyRules = true;
                    MDExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
                if (Methods[0].Equals("CHINESEMD") && (new ChineseDate(model.ForecastTime).LunarMonth + new ChineseDate(model.ForecastTime).LunarDay).Trim().Equals(Methods[1]))
                {
                    //九月廿三日
                    hasOnlyRules = true;
                    CHINESEMDExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
                if (Methods[0].Equals("MIWEEKS") && (
                            model.ForecastTime.Month.ToString().PadLeft(2, '0') +
                            CalculatePoint.GetWeekNumInMonth(model.ForecastTime).ToString().PadLeft(2, '0') +
                            ((int)model.ForecastTime.DayOfWeek).ToString().PadLeft(2, '0')
                        ).Equals(Methods[1]))
                {
                    hasOnlyRules = true;
                    MIWEEKSExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
                if (Methods[0].Equals("EVENT"))
                {
                    hasOnlyRules = true;
                    EVENTExtend(firstName, calMethodModel, result, item, thisCalResult);
                    return result;
                }
            }
            return result;
        }

        private static void EVENTExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqEvent(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }

        private static void MIWEEKSExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqMinute(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }

        private static void CHINESEMDExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqChineseMD(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }

        private static void MDExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqMD(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }

        private static void YMDExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqYMD(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }

        private static void SECONDExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqSecond(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }

        private static void MINUTEExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqMinute(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }

        private static void HOURExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqHour(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }

        private static void WEEKExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqWeek(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }

        private static void DAYExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqDay(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }

        private static void MONTHExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqMonth(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }

        private static void YEAEExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqYear(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }

        private static void BaseExtend(string firstName, List<CalMethodModel> calMethodModel, PointRulerProductModel TotalProduce, KeyValuePair<string, PointRuler> item, CalculatePointModel thisCalResult)
        {
            thisCalResult = CalculatePoint.OUTEqBase(item.Value, thisCalResult);
            calMethodModel.Add(new CalMethodModel { CalMethod = firstName + item.Key, PointChangeLog = thisCalResult.ProducePoints, CalAmount = thisCalResult.ProduceAmounts });
            TotalProduce.TotalProducePoints += thisCalResult.ProducePoints;
            TotalProduce.TotalProduceAmounts += thisCalResult.ProduceAmounts;
            CalculatePoint.ChangeOUTCalculatePointModel(thisCalResult);
        }
    }
}
