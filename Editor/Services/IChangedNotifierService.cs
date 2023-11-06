using Naukri.InspectorMaid.Core;
using System;
using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Services
{
    internal partial interface IChangedNotifierService
    {
        public void ListenValue<T>(string bindingPath, Action<T> callback);

        public void ListenFunc<T>(string bindingPath, object[] args, Action<T> callback);
    }

    partial interface IChangedNotifierService
    {
        public static IChangedNotifierService Of(IBuildContext context)
        {
            return context.GetService<IChangedNotifierService>();
        }
    }

    public static class IChangedNotifierServiceExtensions
    {
        public static void ListenValue<T>(this IBuildContext context, string bindingPath, Action<T> callback)
        {
            var valueChangedListener = IChangedNotifierService.Of(context);
            valueChangedListener.ListenValue(bindingPath, callback);
        }

        public static void ListenFunc<T>(this IBuildContext context, string bindingPath, object[] args, Action<T> callback)
        {
            var valueChangedListener = IChangedNotifierService.Of(context);
            valueChangedListener.ListenFunc(bindingPath, args, callback);
        }

        public static void ListenBindingValue<T>(this IBuildContext context, Action<T> callback)
        {
            var bindingData = context.GetModel<IBindingDataProvider>();
            var bindingInfo = context.GetBindingInfo();

            if (bindingInfo is FieldInfo or PropertyInfo)
            {
                context.ListenValue(bindingData.binding, callback);
            }
            else if (bindingInfo is MethodInfo)
            {
                context.ListenFunc(bindingData.binding, bindingData.args, callback);
            }
        }
    }
}
