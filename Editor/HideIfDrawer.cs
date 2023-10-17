using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class HideIfDrawer : CustomDrawerOf<HideIfAttribute>
    {
        public override DecoratorElement OnDrawDecorator(DecoratorElement child)
        {
            var decorator = new DecoratorElement("HideIf Decorator");
            decorator.OnSceneGUI += Decorator_OnSceneGUI;

            decorator.Add(child);

            return decorator;
        }

        private void Decorator_OnSceneGUI(DecoratorElement decorator)
        {
            var hide = GetBindingValue<bool>();
            if (hide == true)
            {
                decorator.visible = false;
                decorator.style.height = 0;
                decorator.style.width = 0;
            }
            else
            {
                decorator.visible = true;
                decorator.style.height = StyleKeyword.Auto;
                decorator.style.width = StyleKeyword.Auto;
            }
        }
    }
}
