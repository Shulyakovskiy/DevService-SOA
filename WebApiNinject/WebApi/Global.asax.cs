using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using WebApi.Models;
using WebApiContrib.IoC.Ninject;


namespace WebApi
{

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var config = GlobalConfiguration.Configuration;

            var ninjectResolver = NinjectResolver();
            config.DependencyResolver = ninjectResolver;

            WebApiConfig.Register(config);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }

        protected static NinjectResolver NinjectResolver()
        {
            IKernel kernel = new StandardKernel();
            NinjectBinding(kernel);

            var ninjectResolver = new NinjectResolver(kernel);
            return ninjectResolver;
        }

        protected static void NinjectBinding(IKernel kernel)
        {
            kernel.Bind<IReservationRepository>().To<ReservationRepository>();
        }
    }
}