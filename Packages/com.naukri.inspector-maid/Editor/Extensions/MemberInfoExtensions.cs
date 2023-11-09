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

        public static bool IsStatic(this MemberInfo member)
        {
            return member switch
            {
                FieldInfo fieldInfo => fieldInfo.IsStatic,
                PropertyInfo propertyInfo => IsStatic(propertyInfo.GetAccessors(true)[0]),
                MethodBase methodBase => methodBase.IsStatic,
                _ => throw new InvalidOperationException("Unsupport type")
            };
        }
    }
}
