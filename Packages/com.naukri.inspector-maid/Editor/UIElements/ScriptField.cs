using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public sealed class ScriptField : VisualElement
    {
        public ScriptField(SerializedObject serializedObject)
        {
            var m_ScriptProperty = serializedObject.FindProperty("m_Script");

            var scriptField = new PropertyField(m_ScriptProperty).Compose(c =>
            {
                c.enabled = false;
            });

            Add(scriptField);
        }
    }
}
