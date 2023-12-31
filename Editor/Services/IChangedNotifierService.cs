﻿using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using System;
using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Services
{
    internal partial interface IChangedNotifierService
    {
        public void ListenValue(string bindingPath, Action<object> callback);

        public void ListenFunc(string bindingPath, object[] args, Action<object> callback);
    }

    partial interface IChangedNotifierService
    {
        public static IChangedNotifierService Of(IBuildContext context)
        {
            return context.GetService<IChangedNotifierService>();
        }
    }

    public static partial class IBuildContextExtensions
    {
        public static void ListenValue<T>(this IBuildContext context, string bindingPath, Action<T> callback)
        {
            context.ListenValue(bindingPath, v => callback((T)v));
        }

        public static void ListenValue(this IBuildContext context, string bindingPath, Action<object> callback)
        {
            var valueChangedListener = IChangedNotifierService.Of(context);
            valueChangedListener.ListenValue(bindingPath, callback);
        }

        public static void ListenFunc<T>(this IBuildContext context, string bindingPath, object[] args, Action<T> callback)
        {
            context.ListenFunc(bindingPath, args, v => callback((T)v));
        }

        public static void ListenFunc(this IBuildContext context, string bindingPath, object[] args, Action<object> callback)
        {
            var valueChangedListener = IChangedNotifierService.Of(context);
            valueChangedListener.ListenFunc(bindingPath, args, callback);
        }

        public static void ListenBindingValue<T>(this IBuildContext context, Action<T> callback)
        {
            context.ListenBindingValue(v => callback((T)v));
        }

        public static void ListenBindingValue(this IBuildContext context, Action<object> callback)
        {
            if (context.TryGetAttribute(out IBindingDataProvider bindingData))
            {
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
            else
            {
                throw new Exception($"Can not listen binding value, because {context.Widget.GetType().Name} is not {nameof(IBindingDataProvider)}.");
            }
        }
    }
}
