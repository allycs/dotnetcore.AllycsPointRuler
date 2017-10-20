using System;
using System.Linq;

namespace AllycsPointRuler
{
    public static class RulerUtil
    {
        public static bool ContainsOperation(string operation)
        {
            return PointConfigInfo.Rulers.ContainsKey(operation);
        }
        public static void EvaluationOfIntegrals(ForecastPointModel model, PointRulerProductModel pointRulerProduct)
        {
            model.ForecastTime = model.ForecastTime.ToLocalTime();
            var rulDic = PointConfigInfo.Rulers[model.Operation];
            var ListOnlyRule = rulDic.Where(w => w.Value.IsOnly).OrderByDescending(w => w.Value.Weight).ToList();
            var ListMultiRules = rulDic.Where(w => !w.Value.IsOnly).OrderByDescending(w => w.Value.Weight).ToList();

            if (model.Operation.Split('_')[1].Equals("IN", StringComparison.OrdinalIgnoreCase))
            {
                CalculateINPointExtend.CheckRulers(model, ListOnlyRule, ListMultiRules, pointRulerProduct);
            }
            if (model.Operation.Split('_')[1].Equals("OUT", StringComparison.OrdinalIgnoreCase))
            {
                CalculateOUTPointExtend.CheckRulers(model, ListOnlyRule, ListMultiRules, pointRulerProduct);
            }
        }
    }
}