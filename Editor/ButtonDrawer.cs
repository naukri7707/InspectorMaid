using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class ButtonDrawer : CustomDrawerOf<ButtonAttribute>
    {
        public override void OnDrawDecorator(DecoratorElement child)
        {
            // set button
            var action = CreateBindingMethodAction();
            var button = new Button(action)
            {
                text = attribute.text
            };

            if (attribute.width >= 0)
            {
                button.style.width = attribute.width;
            }

            if (attribute.height >= 0)
            {
                button.style.height = attribute.height;
            }

            // set child
            child.style.flexGrow = 1;

            // set decorator
            decorator.style.flexDirection = attribute.flexDirection;

            decorator.Add(button);
            base.OnDrawDecorator(child);
        }
    }
}
