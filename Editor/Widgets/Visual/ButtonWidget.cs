using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class ButtonWidget : ItemWidgetOf<ButtonAttribute>
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
