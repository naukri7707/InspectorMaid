using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class HelpBoxWidget : ItemWidgetOf<HelpBoxAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var helpBox = new HelpBox(attribute.message, attribute.messageType);

            if (attribute.IsBinding())
            {
                context.ListenBindingValue<string>(message =>
                {
                    helpBox.text = message;
                });
            }

            return helpBox;
        }
    }
}
