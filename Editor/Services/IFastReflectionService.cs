using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using System;
using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Services
{
    public partial interface IFastReflectionService
    {
        public object GetValue(string bindingPath);

        public object GetValue(MemberInfo memberInfo);

        public void SetValue(string bindingPath, object value);

        public void SetValue(MemberInfo memberInfo, object value);

        public void InvokeAction(string bindingPath, params object[] args);

        public void InvokeAction(MethodInfo methodInfo, params object[] args);

        public object InvokeFunc(string bindingPath, params object[] args);

        public object InvokeFunc(MethodInfo methodInfo, params object[] args);
    }

    partial interface IFastReflectionService
    {
        public static IFastReflectionService Of(IBuildContext context)
        {
            return context.GetService<IFastReflectionService>();
        }
    }

    public static partial class IBuildContextExtensions
    {
        public static object GetValue(this IBuildContext context, string bindingPath)
        {
            var service = IFastReflectionService.Of(context);
            return service.GetValue(bindingPath);
        }

        public static T GetValue<T>(this IBuildContext context, string bindingPath)
        {
            var service = IFastReflectionService.Of(context);
            return (T)service.GetValue(bindingPath);
        }

        public static void SetValue(this IBuildContext context, string bindingPath, object value)
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

        public static T GetBindingValue<T>(this IBuildContext context)
        {
            return (T)context.GetBindingValue();
        }

        public static object GetBindingValue(this IBuildContext context)
        {
            if (context.TryGetAttribute(out IBindingDataProvider bindingData))
            {
                var bindingInfo = context.GetBindingInfo();

                return bindingInfo switch
                {
                    FieldInfo => GetValue(context, bindingData.binding),
                    PropertyInfo => GetValue(context, bindingData.binding),
                    MethodInfo => InvokeBindingFunc(context),
                    _ => throw new Exception($"Can not get binding value, because the binding '{bindingData.binding}' is not a field, property or method.")
                };
            }
            else
            {
                throw new Exception($"Can not get binding value, because {context.Widget.GetType().Name} is not {nameof(IBindingDataProvider)}.");
            }
        }

        public static void SetBindingValue(this IBuildContext context, object value)
        {
            if (context.TryGetAttribute(out IBindingDataProvider bindingData))
            {
                context.SetValue(bindingData.binding, value);
            }
            else
            {
                throw new Exception($"Can not set binding value, because {context.Widget.GetType().Name} is not {nameof(IBindingDataProvider)}.");
            }
        }

        public static void InvokeBindingAction(this IBuildContext context)
        {
            if (context.TryGetAttribute(out IBindingDataProvider bindingData))
            {
                context.InvokeAction(bindingData.binding, bindingData.args);
            }
            else
            {
                throw new Exception($"Can not invoke binding action, because {context.Widget.GetType().Name} is not {nameof(IBindingDataProvider)}.");
            }
        }

        public static T InvokeBindingFunc<T>(this IBuildContext context)
        {
            return (T)context.InvokeBindingFunc();
        }

        public static object InvokeBindingFunc(this IBuildContext context)
        {
            if (context.TryGetAttribute(out IBindingDataProvider bindingData))
            {
                return context.InvokeFunc(bindingData.binding, bindingData.args);
            }
            else
            {
                throw new Exception($"Can not invoke binding function, because {context.Widget.GetType().Name} is not {nameof(IBindingDataProvider)}.");
            }
        }
    }
}
