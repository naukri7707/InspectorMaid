using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;
using System.ComponentModel.Design;

namespace Naukri.InspectorMaid.Editor.Widgets.Logic
{
    public class ServiceWidget : SingleChildWidget, IServiceContainer, IServiceProvider
    {
        public ServiceWidget()
        {
            services = new ServiceContainer();
        }

        private readonly ServiceContainer services;

        public void AddService(Type serviceType, ServiceCreatorCallback callback) => services.AddService(serviceType, callback);

        public void AddService(Type serviceType, ServiceCreatorCallback callback, bool promote) => services.AddService(serviceType, callback, promote);

        public void AddService(Type serviceType, object serviceInstance) => services.AddService(serviceType, serviceInstance);

        public void AddService(Type serviceType, object serviceInstance, bool promote) => services.AddService(serviceType, serviceInstance, promote);

        public void RemoveService(Type serviceType) => services.RemoveService(serviceType);

        public void RemoveService(Type serviceType, bool promote) => services.RemoveService(serviceType, promote);

        public object GetService(Type serviceType) => services.GetService(serviceType);
    }
}
