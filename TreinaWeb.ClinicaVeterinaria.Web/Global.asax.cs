
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TreinaWeb.ClinicaVeterinaria.IoC;
using TreinaWeb.ClinicaVeterinaria.Aplication.AutoMapper;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace TreinaWeb.ClinicaVeterinaria.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<MapperConfig>());

           // DependencyResolver.SetResolver(SimpleInjectorContainer.RegisterServices());
        }
    }
}
