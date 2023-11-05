using Naukri.InspectorMaid.Editor.Widgets.Core;
using Naukri.InspectorMaid.Editor.Widgets.Logic;

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
    }
}
