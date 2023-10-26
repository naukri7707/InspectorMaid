using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class HelpBoxDrawer : CustomDrawerOf<HelpBoxAttribute>
    {
        private HelpBox helpBox;

        public override void OnStart()
        {
            helpBox = new HelpBox(attribute.message, attribute.messageType);

            decorator.Add(helpBox);
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
