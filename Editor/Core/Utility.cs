using System;
using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Core
{
    internal static class Utility
    {
        public static BindingFlags AllAccessFlags => BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        public static bool HasAttribute<T>(this MemberInfo self) where T : Attribute
        {
            return Attribute.IsDefined(self, typeof(T));
        }
    }
}
