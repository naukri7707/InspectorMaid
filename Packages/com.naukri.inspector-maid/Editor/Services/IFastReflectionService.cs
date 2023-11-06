using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Widgets;
using System;
using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Services
{
    internal partial interface IFastReflectionService
    {
        public object GetValue(MemberInfo memberInfo);

        public object GetValue(string bindingPath);

        public T GetValue<T>(MemberInfo memberInfo);

        public T GetValue<T>(string bindingPath);

        public void InvokeAction(MethodInfo methodInfo, params object[] args);

        public void InvokeAction(string bindingPath, params object[] args);

        public object InvokeFunc(MethodInfo methodInfo, params object[] args);

        public object InvokeFunc(string bindingPath, params object[] args);

        public T InvokeFunc<T>(MethodInfo methodInfo, params object[] args);

        public T InvokeFunc<T>(string bindingPath, params object[] args);

        public void SetValue<T>(MemberInfo memberInfo, T value);

        public void SetValue<T>(string bindingPath, T value);
    }

    partial interface IFastReflectionService
    {
        public static IFastReflectionService Of(IBuildContext context)
        {
            return context.GetService<IFastReflectionService>();
        }
    }

    public static class IFastReflectionServiceExtension
    {
        public static object GetValue(this IBuildContext context, string bindingPath)
        {
            var service = IFastReflectionService.Of(context);
            return service.GetValue(bindingPath);
        }

        public static T GetValue<T>(this IBuildContext context, string bindingPath)
        {
            var service = IFastReflectionService.Of(context);
            return service.GetValue<T>(bindingPath);
        }

        public static void SetValue<T>(this IBuildContext context, string bindingPath, T value)
        {
            var service = IFastReflectionService.Of(context);
            service.SetValue(bindingPath, value);
        }

        public static void InvokeAction(this IBuildContext context, string bindingPath, params object[] args)
        {
            var service = IFastReflectionService.Of(context);
            service.InvokeAction(bindingPath, args);
        }

        public static T InvokeFunc<T>(this IBuildContext context, string bindingPath, params object[] args)
        {
            return (T)context.InvokeFunc(bindingPath, args);
        }

        public static object InvokeFunc(this IBuildContext context, string bindingPath, params object[] args)
        {
            var service = IFastReflectionService.Of(context);
            return service.InvokeFunc(bindingPath, args);
        }

        public static bool IsBinding(this IBuildContext context)
        {
            var bindingData = context.GetModel<IBindingDataProvider>();
            return bindingData.binding != null;
        }

        public static T GetBindingValue<T>(this IBuildContext context)
        {
            return (T)context.GetBindingValue();
        }

        public static object GetBindingValue(this IBuildContext context)
        {
            var bindingData = context.GetModel<IBindingDataProvider>();
            var bindingInfo = context.GetBindingInfo();

            return bindingInfo switch
            {
                FieldInfo => GetValue(context, bindingData.binding),
                PropertyInfo => GetValue(context, bindingData.binding),
                MethodInfo => InvokeBindingFunc(context),
                _ => throw new Exception($"Can not get binding value, because the binding '{bindingData.binding}' is not a field, property or method.")
            };
        }

        public static void SetBindingValue<T>(this IBuildContext context, T value)
        {
            var bindingData = context.GetModel<IBindingDataProvider>();
            context.SetValue(bindingData.binding, value);
        }

        public static void InvokeBindingAction(this IBuildContext context)
        {
            var bindingData = context.GetModel<IBindingDataProvider>();
            context.InvokeAction(bindingData.binding, bindingData.args);
        }

        public static T InvokeBindingFunc<T>(this IBuildContext context)
        {
            return (T)context.InvokeBindingFunc();
        }

        public static object InvokeBindingFunc(this IBuildContext context)
        {
            var bindingData = context.GetModel<IBindingDataProvider>();
            return context.InvokeFunc(bindingData.binding, bindingData.args);
        }

        internal static MemberInfo GetBindingInfo(this IBuildContext context)
        {
            var bindingData = context.GetModel<IBindingDataProvider>();
            var memberWidget = MemberWidget.Of(context);
            var targetType = memberWidget.target.GetType();
            return targetType.GetMember(bindingData.binding)[0];
        }
    }
}
