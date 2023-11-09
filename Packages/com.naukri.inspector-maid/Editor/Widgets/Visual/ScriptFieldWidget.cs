using Naukri.InspectorMaid.Layout;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class ScriptFieldWidget : ItemWidgetOf<ScriptFieldAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var classWidget = ClassWidget.Of(context);

            var serializedProperty = classWidget.serializedObject.FindProperty("m_Script");

            var scriptField = new PropertyField(serializedProperty.Copy()) { name = $"PropertyField:m_Script" };
            scriptField.SetEnabled(false);

            return scriptField;
        }
    }
}
