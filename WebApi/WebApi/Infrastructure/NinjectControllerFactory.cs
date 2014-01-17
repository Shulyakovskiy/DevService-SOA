using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using WebApi.Models;

namespace WebApi.Infrastructure
{
    public class NinjectControllerFactory : IDependencyResolver
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IReservationRepository>().To<ReservationRepository>();
        }


        public object GetService(Type serviceType)
        {
            return _ninjectKernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _ninjectKernel.GetAll(serviceType);
        }
    }
}