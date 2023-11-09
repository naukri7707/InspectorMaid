using Naukri.InspectorMaid.Editor.Contexts;
using System;
using System.ComponentModel.Design;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Logic
{
    public partial class ServiceWidget : Widget, IServiceContainer, IServiceProvider
    {
        public ServiceWidget()
        {
            services = new ServiceContainer();
        }

        private readonly ServiceContainer services;

        public override Context CreateContext() => new SingleChildContext(this);

        public override VisualElement Build(IBuildContext context) => null;

        public void AddService(Type serviceType, ServiceCreatorCallback callback) => services.AddService(serviceType, callback);

        public void AddService(Type serviceType, ServiceCreatorCallback callback, bool promote) => services.AddService(serviceType, callback, promote);

        public void AddService(Type serviceType, object serviceInstance) => services.AddService(serviceType, serviceInstance);

        public void AddService(Type serviceType, object serviceInstance, bool promote) => services.AddService(serviceType, serviceInstance, promote);

        public void RemoveService(Type serviceType) => services.RemoveService(serviceType);

        public void RemoveService(Type serviceType, bool promote) => services.RemoveService(serviceType, promote);

        public object GetService(Type serviceType) => services.GetService(serviceType);
    }

    partial class ServiceWidget
    {
        public static ServiceWidget Of(IBuildContext context)
        {
            return context.GetAncestorWidget<ServiceWidget>();
        }
    }
}
