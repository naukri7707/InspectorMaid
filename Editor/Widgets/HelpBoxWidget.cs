using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class HelpBoxWidget : WidgetOf<HelpBoxAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var helpBox = new HelpBox(model.message, model.messageType);

            if (context.IsBinding())
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
