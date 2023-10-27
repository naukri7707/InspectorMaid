using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using System;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class CustomDrawerOf<TAttribute> : CustomDrawer
        where TAttribute : DrawerAttribute
    {
        private TAttribute _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public TAttribute attribute => _attribute;

        internal override Type AttributeType => typeof(TAttribute);

        protected internal override sealed DrawerAttribute attributeRef
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

        public virtual void OnDestroy()
        { }

        public virtual void OnSceneGUI()
        { }

        public virtual void OnStart()
        { }

        protected internal override Decorator CreateDecorator()
        {
            var name = GetType().Name;

            // if the name end with "Drawer" suffix, remove it.
            if (name.EndsWith("Drawer"))
            {
                name = name[..^6];
            }

            // use nicify name
            name = ObjectNames.NicifyVariableName(name);

            var decorator = new Decorator($"{name} Decorator");

            // use anonymous function to wrap the function so that the function cannot be unregistered
            decorator.OnStart += () => OnStart();
            decorator.OnSceneGUI += () => OnSceneGUI();
            decorator.OnDestroy += () => OnDestroy();

            return decorator;
        }
    }
}
