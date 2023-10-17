using Naukri.InspectorMaid.Editor.Core;

namespace Naukri.InspectorMaid.Editor
{
    public class EnableIfDrawer : CustomDrawerOf<EnableIfAttribute>
    {
        public override DecoratorElement OnDrawDecorator(DecoratorElement child)
        {
            var decorator = new DecoratorElement("EnableIf Decorator");
            decorator.OnSceneGUI += Decorator_OnSceneGUI;

            decorator.Add(child);

            return decorator;
        }

        private void Decorator_OnSceneGUI(DecoratorElement decorator)
        {
            var enable = GetBindingValue<bool>();

            decorator.SetEnabled(enable);
        }
    }
}
