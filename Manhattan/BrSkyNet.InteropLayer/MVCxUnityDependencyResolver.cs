using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BrSkyNet.InteropLayer
{
    public class MVCxUnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _container;

        public MVCxUnityDependencyResolver(
            IUnityContainer container)
        {
            this._container = container;
        }

        public object GetService(Type serviceType)
        {
            if (!_container.IsRegistered(serviceType))
            {
                if (serviceType.IsAbstract || serviceType.IsInterface)
                {
                    return null;
                }
            }
            return _container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType);
        }
    }
}