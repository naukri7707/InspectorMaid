using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.Events;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Receivers;
using System;

namespace Naukri.InspectorMaid.Editor
{
    public interface IWidget : IVisualElement
    {
        public T GetService<T>()
        {
            var serviceProvider = GetFirstAncestorOfType<IServiceProvider>();
            return serviceProvider.GetService<T>();
        }

        public void SendEvent<TReceiver>(Action<TReceiver> callback) where TReceiver : IReceiver;

        public void Repaint()
        {
            using var evt = RepaintEvent.GetPooled();
            evt.target = this;
            SendEvent(evt);
        }
    }
}
