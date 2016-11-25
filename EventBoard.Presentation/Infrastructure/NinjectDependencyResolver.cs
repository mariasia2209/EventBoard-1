using EventBoard.DataAccess.EntityFramework;
using EventBoard.Domain;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EventBoard.Presentation.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IEventBoardContext>().To<EventBoardContext>();

            kernel.Bind<IEventService>().To<EventService>();
        }
    }
}