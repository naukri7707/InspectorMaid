using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Core;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class WidgetStylerOf<TAttribute> : WidgetStyler
        where TAttribute : StylerAttribute
    {
        private TAttribute _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public TAttribute attribute => _attribute;

        internal sealed override Type AttributeType => typeof(TAttribute);

        internal override sealed StylerAttribute attributeRef
        {
            get => _attribute;
            set
            {
                if (value is TAttribute tValue)
                {
                    _attribute = tValue;
                }
            }
        }
    }
}
