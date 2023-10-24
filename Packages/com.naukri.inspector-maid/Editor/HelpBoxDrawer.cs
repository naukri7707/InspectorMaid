using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class HelpBoxDrawer : CustomDrawerOf<HelpBoxAttribute>
    {
        private HelpBox helpBox;

        public override void OnDrawDecorator(DecoratorElement child)
        {
            helpBox = new HelpBox(attribute.message, attribute.messageType);

            decorator.style.flexDirection = attribute.flexDirection;
            decorator.Add(helpBox);

            child.style.flexGrow = 1;

            base.OnDrawDecorator(child);
        }

        public override void OnSceneGUI()
        {
            if (IsBinding)
            {
                var message = GetBindingValue<string>();
                helpBox.text = message;
            }
        }
    }
}
