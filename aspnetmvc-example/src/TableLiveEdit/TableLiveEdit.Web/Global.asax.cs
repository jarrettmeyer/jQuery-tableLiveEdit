using System.Web.Routing;
using Ninject;
using Ninject.Web.Mvc;
using TableLiveEdit.Core.Controllers;
using TableLiveEdit.Core.Lib.Routing;
using TableLiveEdit.Core.Lib.Startup;

namespace TableLiveEdit.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            return ServiceLocator.BuildKernel();
        }

        protected override void OnApplicationStarted()
        {
            RegisterAllControllersIn(typeof(ApplicationController).Assembly);
            RouteRegistrar.RegisterRoutes(RouteTable.Routes);
        }
    }
}