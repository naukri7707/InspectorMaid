using Naukri.InspectorMaid.Editor.Core;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class ElementLabelDrawer : CustomDrawerOf<ElementLabelAttribute>
    {
        private const string kArrayElementClassName = "unity-base-field__label--with-dragger";

        private List<Label> labelElements;

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
            if (IsBinding && labelElements != null)
            {
                var labelText = GetBindingValue<string>();

                for (var i = 0; i < labelElements.Count; i++)
                {
                    var labelElement = labelElements[i];
                    labelElement.text = ActualLabel($"{labelText} {i}");
                }
            }
        }

        public override void OnStart()
        {
            if (memberElement != null)
            {
                labelElements = memberElement.Query<Label>(className: kArrayElementClassName).ToList();
            }

            if (!IsBinding && labelElements != null)
            {
                var labelText = attribute.label;
                for (var i = 0; i < labelElements.Count; i++)
                {
                    var labelElement = labelElements[i];
                    labelElement.text = ActualLabel($"{labelText} {i}");
                }
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
