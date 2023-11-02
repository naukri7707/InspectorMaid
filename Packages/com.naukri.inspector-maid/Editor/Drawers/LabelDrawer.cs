using Naukri.InspectorMaid.Editor.Receivers;
using UnityEditor;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class LabelDrawer : WidgetDrawerOf<LabelAttribute>, IDrawMemeberReceiver
    {
        private Label labelElement;

        public void OnDrawMember(IWidget widget, VisualElement memberElement)
        {
            labelElement = memberElement.Q<Label>();
        }

        public override void OnSceneGUI(IWidget widget)
        {
            if (IsBinding && labelElement != null)
            {
                var labelText = GetBindingValue<string>();

                labelElement.text = ActualLabel(labelText);
            }
        }

        public override void OnStart(IWidget widget)
        {
            if (!IsBinding && labelElement != null)
            {
                var labelText = attribute.label;

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
