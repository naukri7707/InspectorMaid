using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class HelpBoxDrawer : WidgetDrawerOf<HelpBoxAttribute>
    {
        private HelpBox helpBox;

        public override void OnStart(IWidget widget)
        {
            helpBox = new HelpBox(attribute.message, attribute.messageType);

            widget.Add(helpBox);
        }

        public override void OnSceneGUI(IWidget widget)
        {
            if (IsBinding)
            {
                var message = widget.GetBindingValue<string>();

                helpBox.text = message;
            }
        }
    }
}
