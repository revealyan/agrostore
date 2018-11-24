using Agrostore.WebAPI.App_Start;
using Core.Platforms;
using Core.Platforms.Configurations;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;

namespace Agrostore.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            string path = HostingEnvironment.MapPath($"/{WebConfigurationManager.AppSettings["configurationPath"]}");
            var platform = new BasePlatform(new FilePlatformConfiguration(path));
            platform.Startup();
            var httpControllerActivator = new PlatformHttpControllerActivator(platform);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), httpControllerActivator);
        }
    }
}
