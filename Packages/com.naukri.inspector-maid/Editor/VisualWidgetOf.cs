using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Widgets;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Editor
{
    public static class VisualWidgetOfExtensions
    {
        public static bool TryGetAttribute<T>(this IWidget widget, out T attribute)
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

    public abstract class VisualWidgetOf<TAttribute> : VisualWidget, IAttributeProvider, IVisualWidgetProvider
        where TAttribute : WidgetAttribute
    {
        private TAttribute _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public TAttribute attribute => _attribute;

        object IAttributeProvider.Attribute => _attribute;

        Type IVisualWidgetProvider.RegisterType => typeof(TAttribute);

        VisualWidget IVisualWidgetProvider.CloneWith(object attribute)
        {
            var cloned = (VisualWidgetOf<TAttribute>)MemberwiseClone();

            cloned._attribute = attribute switch
            {
                TAttribute tAttribute => tAttribute,
                _ => throw new Exception($"attribute type mismatch."),
            };

            return cloned;
        }
    }
}
