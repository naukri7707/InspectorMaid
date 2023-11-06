using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class ButtonWidget : WidgetOf<ButtonAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var button = new Button(context.InvokeBindingAction)
            {
                text = model.text
            };

            return button;
        }
    }
}
