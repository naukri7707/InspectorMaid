using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class ButtonWidget : VisualWidgetOf<ButtonAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var button = new Button(context.InvokeBindingAction)
            {
                text = attribute.text
            };

            return button;
        }
    }
}
