using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using Naukri.InspectorMaid.Editor.Widgets.Stylers;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class StylerWidgetOf<TAttribute> : StylerWidget, IAttributeProvider, IWidgetProvider
        where TAttribute : WidgetAttribute
    {
        private TAttribute _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public TAttribute attribute => _attribute;

        object IAttributeProvider.Attribute => attribute;

        Type IWidgetProvider.RegisterType => typeof(TAttribute);

        IWidget IWidgetProvider.CloneWith(WidgetAttribute attribute)
        {
            var cloned = (StylerWidgetOf<TAttribute>)MemberwiseClone();

            cloned._attribute = attribute switch
            {
                TAttribute tAttribute => tAttribute,
                _ => throw new Exception($"{nameof(StylerWidgetOf<TAttribute>.attribute)} type mismatch."),
            };

            return cloned;
        }
    }
}
