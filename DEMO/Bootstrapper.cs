using AllycsPointRuler;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace PointRuler
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            RulersXmlUtil.GetRulersDic();
        }
    }
}