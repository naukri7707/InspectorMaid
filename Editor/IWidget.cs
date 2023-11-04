using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.Events;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.Services;
using System;

namespace Naukri.InspectorMaid.Editor
{
    public interface IWidget : IVisualElement
    {
        public object GetValue(string bindingPath)
        {
            var service = FastReflectionService.Of(this);
            return service.GetValue(bindingPath);
        }

        public T GetValue<T>(string bindingPath)
        {
            var service = FastReflectionService.Of(this);
            return service.GetValue<T>(bindingPath);
        }

        public void SetValue<T>(string bindingPath, T value)
        {
            var service = FastReflectionService.Of(this);
            service.SetValue(bindingPath, value);
        }

        public void InvokeAction(string bindingPath, params object[] args)
        {
            var service = FastReflectionService.Of(this);
            service.InvokeAction(bindingPath, args);
        }

        public void InvokeFunc(string bindingPath, params object[] args)
        {
            var service = FastReflectionService.Of(this);
            service.InvokeFunc(bindingPath, args);
        }

        public object GetBindingValue()
        {
            var bindable = GetBindable();
            return GetValue(bindable.binding);
        }

        public T GetBindingValue<T>()
        {
            var bindable = GetBindable();
            return GetValue<T>(bindable.binding);
        }

        public void SetBindingValue<T>(T value)
        {
            var bindable = GetBindable();
            SetValue(bindable.binding, value);
        }

        public void InvokeBindingAction()
        {
            var bindable = GetBindable();
            InvokeAction(bindable.binding, bindable.args);
        }

        public void InvokeBindingFunc()
        {
            var bindable = GetBindable();
            InvokeFunc(bindable.binding, bindable.args);
        }

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

        private IBindable GetBindable()
        {
            if (this is IWidgetDrawerProvider drawerProvider)
            {
                var widgetDrawer = drawerProvider.GetWidgetDrawer();

                if (widgetDrawer.attributeRef is IBindable bindable)
                {
                    return bindable;
                }
                else
                {
                    throw new Exception($"Can not get binding value, because the attribute '{widgetDrawer.attributeRef.GetType().Name}' is not {nameof(IBindable)}.");
                }
            }
            else
            {
                throw new Exception($"Can not get binding value, because the widget '{GetType().Name}' is not {nameof(IWidgetDrawerProvider)}.");
            }
        }
    }
}
