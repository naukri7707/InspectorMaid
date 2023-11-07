using Naukri.InspectorMaid.Editor.Widgets.Core;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class IWidgetExtensions
    {
        internal static bool TryGetAttribute<T>(this IWidget widget, out T attribute)
        {
            if (widget is IAttributeProvider attributeProvider)
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
