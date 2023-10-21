using Naukri.InspectorMaid.Core;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class CustomDrawerOf<TAttribute> : CustomDrawerWithDecoratorOf<TAttribute, DecoratorElement>
        where TAttribute : InspectorMaidAttribute
    {
        public virtual void OnDestroy()
        { }

        public virtual void OnSceneGUI()
        { }

        public virtual void OnStart()
        { }

        protected override sealed DecoratorElement CreateDecorator()
        {
            var name = GetType().Name;

            // if the name end with "Drawer" suffix, remove it.
            if (name.EndsWith("Drawer"))
            {
                name = name[..^6];
            }

            // use nicify name
            name = ObjectNames.NicifyVariableName(name);

            var decorator = new DecoratorElement($"{name} Decorator");

            // use anonymous function to wrap the function so that the function cannot be unregistered
            decorator.OnStart += () => OnStart();
            decorator.OnSceneGUI += () => OnSceneGUI();
            decorator.OnDestroy += () => OnDestroy();

            return decorator;
        }
    }
}
