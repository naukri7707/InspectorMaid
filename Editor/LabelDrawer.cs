using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class LabelDrawer : CustomDrawerOf<LabelAttribute>
    {
        private Label labelElement;

        private VisualElement memberElement;

        public override void OnDrawField(PropertyField fieldElement)
        {
            memberElement = fieldElement;
        }

        public override void OnDrawMethod(MethodElement methodElement)
        {
            memberElement = methodElement;
        }

        public override void OnDrawProperty(PropertyElement propertyElement)
        {
            memberElement = propertyElement;
        }

        public override void OnSceneGUI()
        {
            if (IsBinding && labelElement != null)
            {
                var labelText = GetBindingValue<string>();

                labelElement.text = ActualLabel(labelText);
            }
        }

        public override void OnStart()
        {
            if (memberElement != null)
            {
                labelElement = memberElement.Q<Label>();
            }

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
