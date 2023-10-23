using Naukri.InspectorMaid.Core;
using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class CustomStyler
    {
        internal abstract Type AttributeType { get; }

        [SuppressMessage("Style", "IDE1006")]
        protected internal abstract StylerAttribute attributeRef { get; set; }

        public abstract void OnStyling(IStyle style);

        internal CustomStyler CloneWith(StylerAttribute attribute)
        {
            var cloned = (CustomStyler)MemberwiseClone();
            cloned.attributeRef = attribute;
            return cloned;
        }
    }
}
