using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class ButtonWidget : VisualWidgetOf<ButtonAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            void buttonAction()
            {
                if (attribute.setDirty)
                {
                    context.RecordAndSetDirty("Button Pressed");
                }
                context.InvokeBindingAction();
            }

            var button = new Button(buttonAction)
            {
                text = attribute.text
            };

            return button;
        }
    }
}
