using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;

namespace DodoWare.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)?.Info("Logging initialized.");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
