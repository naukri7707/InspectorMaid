using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class ItemWidgetOf<TAttribute> : ItemWidget, IAttributeProvider, IWidgetProvider
        where TAttribute : ItemAttribute
    {
        private TAttribute _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public TAttribute attribute => _attribute;

        object IAttributeProvider.Attribute => _attribute;

        Type IWidgetProvider.RegisterType => typeof(TAttribute);

        IWidget IWidgetProvider.CloneWith(WidgetAttribute attribute)
        {
            var cloned = (ItemWidgetOf<TAttribute>)MemberwiseClone();

            cloned._attribute = attribute switch
            {
                TAttribute tAttribute => tAttribute,
                _ => throw new Exception($"attribute type mismatch."),
            };

            return cloned;
        }
    }
}
