using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.Events;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.Services;
using System;
using System.Reflection;

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

        public T InvokeFunc<T>(string bindingPath, params object[] args)
        {
            return (T)InvokeFunc(bindingPath, args);
        }

        public object InvokeFunc(string bindingPath, params object[] args)
        {
            var service = FastReflectionService.Of(this);
            return service.InvokeFunc(bindingPath, args);
        }

        public T GetBindingValue<T>()
        {
            return (T)GetBindingValue();
        }

        public object GetBindingValue()
        {
            var widgetDrawer = GetWidgetDrawer();
            var bindable = GetBindable();
            var targetType = widgetDrawer.target.GetType();
            var bindingInfo = targetType.GetMemberToBase(InspectorMaidUtility.BaseType, bindable.binding);

            return bindingInfo switch
            {
                FieldInfo => GetValue(bindable.binding),
                PropertyInfo => GetValue(bindable.binding),
                MethodInfo => InvokeBindingFunc(),
                _ => throw new Exception($"Can not get binding value, because the binding '{bindable.binding}' is not a field, property or method.")
            };
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

        public T InvokeBindingFunc<T>()
        {
            return (T)InvokeBindingFunc();
        }

        public object InvokeBindingFunc()
        {
            var bindable = GetBindable();
            return InvokeFunc(bindable.binding, bindable.args);
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
            var widgetDrawer = GetWidgetDrawer();

            if (widgetDrawer.attributeRef is IBindable bindable)
            {
                return bindable;
            }
            else
            {
                throw new Exception($"Can not get binding value, because the attribute '{widgetDrawer.attributeRef.GetType().Name}' is not {nameof(IBindable)}.");
            }
        }

        private WidgetDrawer GetWidgetDrawer()
        {
            if (this is IWidgetDrawerProvider drawerProvider)
            {
                return drawerProvider.GetWidgetDrawer();
            }
            else
            {
                throw new Exception($"Can not get binding value, because the widget '{GetType().Name}' is not {nameof(IWidgetDrawerProvider)}.");
            }
        }
    }
}
