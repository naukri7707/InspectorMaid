using Naukri.InspectorMaid.Editor.Receivers;
using UnityEditor;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class LabelDrawer : WidgetDrawerOf<LabelAttribute>, IDrawMemeberReceiver
    {
        private VisualElement memberElement;

        private Label labelElement;

        public void OnDrawMember(IWidget widget, VisualElement memberElement)
        {
            this.memberElement = memberElement;
        }

        public override void OnStart(IWidget widget)
        {
            // we should get labelElement on start,
            // because labelElement will build while widget attach to panel.
            // so if we get labelElement on OnDrawMember, it will be null.
            labelElement = memberElement.Q<Label>();

            if (!IsBinding && labelElement != null)
            {
                var labelText = attribute.label;

                labelElement.text = ActualLabel(labelText);
            }
        }

        public override void OnSceneGUI(IWidget widget)
        {
            if (IsBinding && labelElement != null)
            {
                var labelText = GetBindingValue<string>();

                labelElement.text = ActualLabel(labelText);
            }
        }

        private string ActualLabel(string labelText)
        {
            return attribute.useNicifyName
                ? ObjectNames.NicifyVariableName(labelText)
                : labelText;
        }
    }
}
