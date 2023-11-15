using Naukri.InspectorMaid.Editor.UIElements.Compose;
using Naukri.InspectorMaid.Layout;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class ScriptFieldWidget : ItemWidgetOf<ScriptFieldAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var classWidget = ClassWidget.Of(context);
            var serializedObject = classWidget.serializedObject;

            var scriptField = new ScriptField(serializedObject);

            return scriptField;
        }

        private class ScriptField : VisualElement
        {
            public ScriptField(SerializedObject serializedObject)
            {
                var serializedProperty = serializedObject.FindProperty("m_Script");

                var scriptField = new PropertyField(serializedProperty.Copy()).Compose(c =>
                {
                    c.enabled = false;
                });

                Add(scriptField);
            }
        }
    }
}
