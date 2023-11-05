using System;
using System.Reflection;
using UnityEngine;

namespace Naukri.InspectorMaid.Editor.Helpers
{
    internal static class InspectorMaidUtility
    {
        public const BindingFlags kAllAccessFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        public const BindingFlags kAllDeclaredAccessFlags = kAllAccessFlags | BindingFlags.DeclaredOnly;

        public static Type BaseType = typeof(MonoBehaviour); // this should be same as InspectorMaidEditor's CustomEditor attribute

        public static bool HasAttribute<T>(this MemberInfo self) where T : Attribute
        {
            return Attribute.IsDefined(self, typeof(T));
        }
    }
}
