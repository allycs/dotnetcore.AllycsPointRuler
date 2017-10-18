using AllycsPointRuler;
using Nancy;
using Nancy.ModelBinding;
using PointRuler.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointRuler.Modules
{
    public class MainModule:NancyModule
    {
        public MainModule()
        { 
            //获取基本规则
            Get("/universal/ruler-info", _ => GetRulerInfo());
            //上传配置xml
            Post("/universal/ruler-info", _ => SetRulerInfo());
            //设定规则立即生效
            Post("/universal/start-using", _ => StartusingRuleXml());
            //预估积分
            Post("/universal/forecast-Points", _ => ForecastPointUse());
        }
        private object StartusingRuleXml()
        {
            var model = this.Bind<UsingRuleXmlModel>();
            RulersXmlUtil.GetRulersDic(model.FileName);
            return Response.AsText("");
        }

        private object GetRulerInfo()
        {
            return Response.AsJson(PointConfigInfo.Rulers);
        }

        private object SetRulerInfo()
        {
            var successFiles = new List<string>();
            var failedFiles = new List<PointRulerErrFileModel>();
            if (!Request.Files.Any())
                return Response.AsText("请上传配置文件").WithStatusCode(HttpStatusCode.BadRequest);
            foreach (var file in Request.Files)
            {
                if (!file.Name.Split(".").Last().Equals("XML", StringComparison.OrdinalIgnoreCase))
                {
                    failedFiles.Add(new PointRulerErrFileModel { FileName = file.Name, ErrMsg = "该文件类型错误" });
                }
                var resultCode = RulersXmlUtil.AddNewRuleXml(file.Name, file.Value);
                if (resultCode != RuleXmlCode.SUCCESS)
                    failedFiles.Add(new PointRulerErrFileModel { FileName = file.Name, ErrMsg = resultCode.ToString() });
                else
                    successFiles.Add(file.Name);
            }
            return Response.AsJson(new { SuccessFiles = successFiles, FailedFiles = failedFiles });
        }

        private object ForecastPointUse()
        {
            var model = this.Bind<AllycsPointRuler.ForecastPointModel>();
            if (!PointConfigInfo.Rulers.ContainsKey(model.Operation))
                return Response.AsText("触发类型未设定").WithStatusCode(HttpStatusCode.BadRequest);

            model.ForecastTime = model.ForecastTime.ToLocalTime();
            var rulDic = PointConfigInfo.Rulers[model.Operation];
            var ListOnlyRule = rulDic.Where(w => w.Value.IsOnly == true).OrderByDescending(w => w.Value.Weight).ToList();
            var ListMultiRules = rulDic.Where(w => w.Value.IsOnly == false).OrderByDescending(w => w.Value.Weight).ToList();

            var calMethodModel = new List<CalMethodModel>();
            int TotalProducePoint = 0;
            if (model.Operation.Split('_')[1].Equals("IN", StringComparison.OrdinalIgnoreCase))
            {
                TotalProducePoint = CalculateINPointExtend.CheckRulers(model, ListOnlyRule, ListMultiRules, calMethodModel, TotalProducePoint);
                return Response.AsJson(new 
                {
                    ResultCode = "SUCCESS",
                    ResultMsg = "预测生成积分成功",
                    OriginalAmounts = model.Amount,
                    OriginalPoints = model.Points,
                    UsedAmounts = 0,
                    LeftAmounts = model.Amount,
                    UsedPoints = 0,
                    LeftPoints = model.Points + TotalProducePoint,
                    NewPoints = TotalProducePoint,
                    CalMethods = calMethodModel,
                });
            }
            if (model.Operation.Split('_')[1].Equals("OUT", StringComparison.OrdinalIgnoreCase))
            {
                var pointRulerProduct = CalculateOUTPointExtend.CheckRulers(model, ListOnlyRule, ListMultiRules, calMethodModel);
                return Response.AsJson(new 
                {
                    ResultCode = "SUCCESS",
                    ResultMsg = "预测使用积分成功",
                    OriginalAmounts = model.Amount,
                    OriginalPoints = model.Points,
                    UsedAmounts = pointRulerProduct.TotalProduceAmounts,
                    LeftAmounts = model.Amount - pointRulerProduct.TotalProduceAmounts,
                    UsedPoints = pointRulerProduct.TotalProducePoints,
                    LeftPoints = model.Points + pointRulerProduct.TotalProducePoints,
                    NewPoints = -pointRulerProduct.TotalProducePoints,
                    CalMethods = calMethodModel,
                });
            }

            return Response.AsJson(new 
            {
                ResultCode = "SUCCESS",
                ResultMsg = "预测积分成功",
                OriginalAmounts = model.Amount,
                OriginalPoints = model.Points,
                UsedAmounts = 0,
                LeftAmounts = 0,
                UsedPoints = 0,
                LeftPoints = 0,
                NewPoints = 0,
                CalMethods = calMethodModel
            });
        }
    }
}
