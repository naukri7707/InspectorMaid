﻿using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Services.Default
{
    internal sealed class FastReflectionService : IFastReflectionService
    {
        public FastReflectionService(object target)
        {
            this.target = target;
            targetType = target.GetType();
        }

        private readonly object target;

        private readonly Type targetType;

        private readonly Dictionary<string, FRGetter<object, object>> getters = new();

        private readonly Dictionary<string, FRSetter<object, object>> setters = new();

        private readonly Dictionary<string, FRAction<object>> actions = new();

        private readonly Dictionary<string, FRFunc<object, object>> functions = new();

        public object GetValue(string bindingPath)
        {
            var memberInfo = targetType.GetMemberToBase(InspectorMaidUtility.kBaseType, bindingPath);
            return GetValue(memberInfo);
        }

        public object GetValue(MemberInfo memberInfo)
        {
            var getter = GetOrCreateGetter(memberInfo);
            return getter(target);
        }

        public void SetValue(string bindingPath, object value)
        {
            var memberInfo = targetType.GetMemberToBase(InspectorMaidUtility.kBaseType, bindingPath);
            SetValue(memberInfo, value);
        }

        public void SetValue(MemberInfo memberInfo, object value)
        {
            var setter = GetOrCreateSetter(memberInfo);
            setter(target, value);
        }

        public void InvokeAction(string bindingPath, params object[] args)
        {
            var methodInfo = targetType.GetMethodToBase(InspectorMaidUtility.kBaseType, bindingPath);
            InvokeAction(methodInfo, args);
        }

        public void InvokeAction(MethodInfo methodInfo, params object[] args)
        {
            var action = GetOrCreateAction(methodInfo);
            action(target, args);
        }

        public object InvokeFunc(string bindingPath, params object[] args)
        {
            var methodInfo = targetType.GetMethodToBase(InspectorMaidUtility.kBaseType, bindingPath);
            return InvokeFunc(methodInfo, args);
        }

        public object InvokeFunc(MethodInfo methodInfo, params object[] args)
        {
            var func = GetOrCreateFunc(methodInfo);
            return func(target, args);
        }

        private FRGetter<object, object> GetOrCreateGetter(MemberInfo memberInfo)
        {
            var memberName = memberInfo.Name;

            if (!getters.TryGetValue(memberName, out var getter))
            {
                getter = memberInfo switch
                {
                    FieldInfo fieldInfo => FastReflection.Polymorphism.CreateGetter<object, object>(fieldInfo, targetType),
                    PropertyInfo propertyInfo => FastReflection.Polymorphism.CreateGetter<object, object>(propertyInfo, targetType),
                    _ => throw new Exception($"Can not create getter, because the '{memberName}' is not a field or property."),
                };

                getters.Add(memberName, getter);
            }

            return getter;
        }

        private FRSetter<object, object> GetOrCreateSetter(MemberInfo memberInfo)
        {
            var memberName = memberInfo.Name;

            if (!setters.TryGetValue(memberName, out var setter))
            {
                setter = memberInfo switch
                {
                    FieldInfo fieldInfo => FastReflection.Polymorphism
                        .CreateSetter<object, object>(fieldInfo, targetType),
                    PropertyInfo propertyInfo => FastReflection.Polymorphism
                        .CreateSetter<object, object>(propertyInfo, targetType),
                    _ => throw new Exception($"Can not create setter, because the '{memberName}' is not a field or property."),
                };

                setters.Add(memberName, setter);
            }

            return setter;
        }

        private FRAction<object> GetOrCreateAction(MethodInfo methodInfo)
        {
            var methodName = methodInfo.Name;

            if (!actions.TryGetValue(methodName, out var action))
            {
                action = FastReflection.Polymorphism.CreateAction<object>(methodInfo, targetType);

                actions.Add(methodName, action);
            }

            return action;
        }

        private FRFunc<object, object> GetOrCreateFunc(MethodInfo methodInfo)
        {
            var methodName = methodInfo.Name;

            if (!functions.TryGetValue(methodName, out var func))
            {
                func = FastReflection.Polymorphism.CreateFunc<object, object>(methodInfo, targetType);

                functions.Add(methodName, func);
            }

            return func;
        }
    }
}
