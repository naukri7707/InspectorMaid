using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class LabelWidget : VisualWidgetOf<LabelAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var label = new Label()
            {
                text = attribute.text
            };

            if (attribute.IsBinding())
            {
                context.ListenBindingValue<string>(message =>
                {
                    label.text = message;
                });
            }

            return label;
        }
    }
}
