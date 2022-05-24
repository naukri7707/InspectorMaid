using Naukri.InspectorMaid.Core;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class CustomStylerOf<TAttribute> : CustomStyler
        where TAttribute : StylerAttribute
    {
        private TAttribute _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public TAttribute attribute => _attribute;

        internal sealed override Type AttributeType => typeof(TAttribute);

        protected internal override sealed StylerAttribute attributeRef
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
