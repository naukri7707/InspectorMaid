using Naukri.InspectorMaid.Editor.Widgets.Core;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class ScriptFieldWidget : ItemWidget
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
