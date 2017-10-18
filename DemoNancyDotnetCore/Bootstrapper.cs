using AllycsPointRuler;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoNancyDotnetCore
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            RulersXmlUtil.GetRulersDic();
        }
    }
}
