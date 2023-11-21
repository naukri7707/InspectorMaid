using Naukri.InspectorMaid.Core;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class WidgetOf<TAttribute> : Widget, IWidgetProvider
        where TAttribute : WidgetAttribute
    {
        private TAttribute _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public TAttribute attribute => _attribute;

        object IAttributeProvider.Attribute => _attribute;

        Type IWidgetProvider.RegisterType => typeof(TAttribute);

        Widget IWidgetProvider.CloneWith(WidgetAttribute attribute)
        {
            var cloned = (WidgetOf<TAttribute>)MemberwiseClone();

            cloned._attribute = attribute switch
            {
                TAttribute tAttribute => tAttribute,
                _ => throw new Exception($"attribute type mismatch."),
            };

            return cloned;
        }
    }
}
