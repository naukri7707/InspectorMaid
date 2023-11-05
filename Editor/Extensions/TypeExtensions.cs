using Naukri.InspectorMaid.Editor.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class TypeExtensions
    {
        public static MemberInfo[] GetMembersFromBase(this Type targetType, Type baseType)
        {
            return GetTypeFromBase(targetType, baseType).SelectMany(it =>
            {
                return it.GetMembers(InspectorMaidUtility.kAllDeclaredAccessFlags);
            }).ToArray();
        }

        public static FieldInfo[] GetFieldsFromBase(this Type targetType, Type baseType)
        {
            return GetTypeFromBase(targetType, baseType).SelectMany(it =>
            {
                return it.GetFields(InspectorMaidUtility.kAllDeclaredAccessFlags);
            }).ToArray();
        }

        public static PropertyInfo[] GetPropertiesFromBase(this Type targetType, Type baseType)
        {
            return GetTypeFromBase(targetType, baseType).SelectMany(it =>
            {
                return it.GetProperties(InspectorMaidUtility.kAllDeclaredAccessFlags);
            }).ToArray();
        }

        public static MethodInfo[] GetMethodsFromBase(this Type targetType, Type baseType)
        {
            return GetTypeFromBase(targetType, baseType).SelectMany(it =>
            {
                return it.GetMethods(InspectorMaidUtility.kAllDeclaredAccessFlags);
            }).ToArray();
        }

        public static MemberInfo GetMemberToBase(this Type targetType, Type baseType, string name)
        {
            return GetTypeToBase(targetType, baseType)
                .SelectMany(t => t.GetMember(name, InspectorMaidUtility.kAllDeclaredAccessFlags))
                .FirstOrDefault(f => f != null);
        }

        public static FieldInfo GetFieldToBase(this Type targetType, Type baseType, string name)
        {
            return GetTypeToBase(targetType, baseType)
                .Select(t => t.GetField(name, InspectorMaidUtility.kAllDeclaredAccessFlags))
                .FirstOrDefault(f => f != null);
        }

        public static PropertyInfo GetPropertyToBase(this Type targetType, Type baseType, string name)
        {
            return GetTypeToBase(targetType, baseType)
                 .Select(t => t.GetProperty(name, InspectorMaidUtility.kAllDeclaredAccessFlags))
                 .FirstOrDefault(p => p != null);
        }

        public static MethodInfo GetMethodToBase(this Type targetType, Type baseType, string name)
        {
            return GetTypeToBase(targetType, baseType)
                 .Select(t => t.GetMethod(name, InspectorMaidUtility.kAllDeclaredAccessFlags))
                 .FirstOrDefault(m => m != null);
        }

        public static IEnumerable<Type> GetTypeFromBase(this Type targetType, Type baseType)
        {
            return GetTypeToBase(targetType, baseType).Reverse();
        }

        public static IEnumerable<Type> GetTypeToBase(this Type targetType, Type baseType)
        {
            Type currentType = targetType;

            while (currentType != null && currentType != baseType)
            {
                yield return currentType;

                currentType = currentType.BaseType;
            }
        }
    }
}
