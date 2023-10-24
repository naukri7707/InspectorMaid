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

            decorator.Add(helpBox);

            // Set flexGrow to 1, so that the child can fill the entire decorator,
            // this is particularly useful when flexDricetion is row
            child.style.flexGrow = 1;

            // In order to unify the design logic, the newly added child elements must be added before the child decorator
            // so here we need to set the flex-direction of the decorator to column-reverse
            // let helpBox be below the decorator by default
            decorator.style.flexDirection = FlexDirection.ColumnReverse;

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
