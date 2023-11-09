using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using Naukri.InspectorMaid.Editor.Widgets.Logic;
using Naukri.InspectorMaid.Editor.Widgets.Visual;
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

        internal static MemberInfo GetBindingInfo(this IBuildContext context)
        {
            if (context.TryGetAttribute(out IBindingDataProvider bindingData))
            {
                var classWidget = ClassWidget.Of(context);
                var targetType = classWidget.target.GetType();
                return targetType.GetMemberToBase(InspectorMaidUtility.kBaseType, bindingData.binding);
            }
            return null;
        }
    }
}
