using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class ScriptFieldWidget : Widget
    {
        public ScriptFieldWidget(SerializedProperty serializedProperty)
        {
            this.serializedProperty = serializedProperty;
        }

        private readonly SerializedProperty serializedProperty;

        public override VisualElement Build(IBuildContext context)
        {
            var scriptField = new PropertyField(serializedProperty.Copy()) { name = $"PropertyField:m_Script" };
            scriptField.SetEnabled(false);
            return scriptField;
        }
    }
}
