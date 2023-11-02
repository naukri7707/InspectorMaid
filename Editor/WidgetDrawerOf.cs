using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using System;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class WidgetDrawerOf<TAttribute> : WidgetDrawer
        where TAttribute : DrawerAttribute
    {
        private TAttribute _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public TAttribute attribute => _attribute;

        internal override sealed DrawerAttribute attributeRef
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

        internal override Type AttributeType => typeof(TAttribute);

        internal override Widget CreateWidget()
        {
            var name = GetType().Name;

            // if the name end with "Drawer" suffix, remove it.
            if (name.EndsWith("Drawer"))
            {
                name = name[..^6];
            }

            // use nicify name
            name = ObjectNames.NicifyVariableName(name);

            var widget = new Widget(this, $"{name} Widget");

            return widget;
        }
    }
}
