using Naukri.InspectorMaid.Core;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class CustomDrawerOf<T> : CustomDrawer where T : InspectorMaidAttribute
    {
        private T _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public T attribute => _attribute;

        internal override Type AttributeType => typeof(T);

        protected internal override sealed InspectorMaidAttribute attributeRef
        {
            get => _attribute;
            set
            {
                if (value is T tValue)
                {
                    _attribute = tValue;
                }
            }
        }
    }
}
