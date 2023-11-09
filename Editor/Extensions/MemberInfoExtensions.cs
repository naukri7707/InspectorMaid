using System;
using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class MemberInfoExtensions
    {
        public static bool HasAttribute<T>(this MemberInfo self) where T : Attribute
        {
            return Attribute.IsDefined(self, typeof(T));
        }
    }
}
