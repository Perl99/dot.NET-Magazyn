using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using Ninject;
using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;


namespace GameStore.WebUI.Infrastructure
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
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<IUserRepository>().To<EFUserRepository>();
            kernel.Bind<IAuctionRepository>().To<EFAuctionRepository>();
            kernel.Bind<IOfferRepository>().To<EFOfferRepository>();
            kernel.Bind<EFDbContext>().To<EFDbContext>().InSingletonScope();
        }
    }
}