using Naukri.InspectorMaid.Editor.Receivers;
using System;
using System.ComponentModel.Design;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    internal sealed class InspectorMaidElement : VisualElement, IWidget, IServiceContainer, IServiceProvider
    {
        public InspectorMaidElement()
        {
            services = new ServiceContainer();
        }

        private readonly ServiceContainer services;

        public IStyle Style => style;

        public VisualElement Parent => parent;

        public void AddService(Type serviceType, ServiceCreatorCallback callback) => services.AddService(serviceType, callback);

        public void AddService(Type serviceType, ServiceCreatorCallback callback, bool promote) => services.AddService(serviceType, callback, promote);

        public void AddService(Type serviceType, object serviceInstance) => services.AddService(serviceType, serviceInstance);

        public void AddService(Type serviceType, object serviceInstance, bool promote) => services.AddService(serviceType, serviceInstance, promote);

        public void RemoveService(Type serviceType) => services.RemoveService(serviceType);

        public void RemoveService(Type serviceType, bool promote) => services.RemoveService(serviceType, promote);

        public object GetService(Type serviceType) => services.GetService(serviceType);

        public void SendEvent<TReceiver>(Action<TReceiver> callback) where TReceiver : IReceiver
        {
            this.Query<Widget>().ForEach(w => w.SendEvent(callback));
        }
    }
}
