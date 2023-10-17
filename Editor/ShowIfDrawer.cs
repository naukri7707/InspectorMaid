using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class ShowIfDrawer : CustomDrawerOf<ShowIfAttribute>
    {
        public override DecoratorElement OnDrawDecorator(DecoratorElement child)
        {
            var decorator = new DecoratorElement("ShowIf Decorator");
            decorator.OnSceneGUI += Decorator_OnSceneGUI;

            decorator.Add(child);

            return decorator;
        }

        private void Decorator_OnSceneGUI(DecoratorElement decorator)
        {
            var show = GetBindingValue<bool>();
            if (show == true)
            {
                decorator.visible = true;
                decorator.style.height = StyleKeyword.Auto;
                decorator.style.width = StyleKeyword.Auto;
            }
            else
            {
                decorator.visible = false;
                decorator.style.height = 0;
                decorator.style.width = 0;
            }
        }
    }
}
