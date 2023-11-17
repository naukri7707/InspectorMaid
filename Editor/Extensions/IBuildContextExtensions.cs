using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using Naukri.InspectorMaid.Editor.Widgets.Logic;
using Naukri.InspectorMaid.Editor.Widgets.Visual;
using System;
using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class IBuildContextExtensions
    {
        public static T GetService<T>(this IBuildContext context)
        {
            var provider = context.GetAncestorWidget<ServiceWidget>();
            return provider.GetService<T>();
        }

        public static Type GetBindingValueType(this IBuildContext context)
        {
            if (context.TryGetAttribute(out IBindingDataProvider bindingData))
            {
                return GetValueType(context, bindingData.binding);
            }
            return null;
        }

        public static Type GetValueType(this IBuildContext context, string memberName)
        {
            var memberInfo = context.GetInfo(memberName);

            return memberInfo.MemberType switch
            {
                MemberTypes.Field => (memberInfo as FieldInfo).FieldType,
                MemberTypes.Property => (memberInfo as PropertyInfo).PropertyType,
                MemberTypes.Method => (memberInfo as MethodInfo).ReturnType,
                _ => null
            };
        }

        public static MemberInfo GetBindingInfo(this IBuildContext context)
        {
            if (context.TryGetAttribute(out IBindingDataProvider bindingData))
            {
                return GetInfo(context, bindingData.binding);
            }
            return null;
        }

        public static MemberInfo GetInfo(this IBuildContext context, string memberName)
        {
            var classWidget = ClassWidget.Of(context);
            var targetType = classWidget.target.GetType();
            return targetType.GetMemberToBase(InspectorMaidUtility.kBaseType, memberName);
        }

        internal static bool TryGetAttribute<T>(this IBuildContext context, out T attribute)
        {
            if (context.Widget is IAttributeProvider attributeProvider)
            {
                if (attributeProvider.Attribute is T tAttribute)
                {
                    attribute = tAttribute;
                    return true;
                }
            }

            attribute = default;
            return false;
        }
    }
}
