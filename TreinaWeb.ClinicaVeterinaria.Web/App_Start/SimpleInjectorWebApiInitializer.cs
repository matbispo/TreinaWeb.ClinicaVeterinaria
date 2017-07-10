[assembly: WebActivator.PostApplicationStartMethod(typeof(TreinaWeb.ClinicaVeterinaria.Web.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]


namespace TreinaWeb.ClinicaVeterinaria.Web.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TreinaWeb.ClinicaVeterinaria.IoC;
    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Integration.Web;
    using System.Reflection;
    using System.Web.Mvc;

    public static class SimpleInjectorWebApiInitializer
    {
        public static void Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }

        private static void InitializeContainer(Container container)
        {
            SimpleInjectorContainer.RegisterServices(container);
        }
    }
}