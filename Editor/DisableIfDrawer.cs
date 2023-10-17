using Naukri.InspectorMaid.Editor.Core;

namespace Naukri.InspectorMaid.Editor
{
    public class DisableIfDrawer : CustomDrawerOf<DisableIfAttribute>
    {
        public override DecoratorElement OnDrawDecorator(DecoratorElement child)
        {
            var decorator = new DecoratorElement("DisableIf Decorator");
            decorator.OnSceneGUI += Decorator_OnSceneGUI;

            decorator.Add(child);

            return decorator;
        }

        private void Decorator_OnSceneGUI(DecoratorElement decorator)
        {
            var disable = GetBindingValue<bool>();

            decorator.SetEnabled(!disable);
        }
    }
}
