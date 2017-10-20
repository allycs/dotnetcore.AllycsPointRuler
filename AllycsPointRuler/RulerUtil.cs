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
        public static ListRules GetSortRules(string operation)
        {
            var rulDic = PointConfigInfo.Rulers[operation];
            var ListOnlyRules = rulDic.Where(w => w.Value.IsOnly).OrderByDescending(w => w.Value.Weight).ToList();
            var ListMultiRules = rulDic.Where(w => !w.Value.IsOnly).OrderByDescending(w => w.Value.Weight).ToList();
            return new ListRules { OnlyRules = ListOnlyRules, MultiRules = ListMultiRules };
        }
        public static void EvaluationOfIntegrals(ForecastPointModel model, PointRulerProductModel pointRulerProduct)
        {
            model.ForecastTime = model.ForecastTime.ToLocalTime();
            if (!ContainsOperation(model.Operation)) return;
            var listRules = GetSortRules(model.Operation);

            if (model.Operation.Split('_')[1].Equals("IN", StringComparison.OrdinalIgnoreCase))
            {
                CalculateINPointExtend.CheckRulers(model, listRules.OnlyRules, listRules.MultiRules, pointRulerProduct);
            }
            if (model.Operation.Split('_')[1].Equals("OUT", StringComparison.OrdinalIgnoreCase))
            {
                CalculateOUTPointExtend.CheckRulers(model, listRules.OnlyRules, listRules.MultiRules, pointRulerProduct);
            }
        }
    }
}