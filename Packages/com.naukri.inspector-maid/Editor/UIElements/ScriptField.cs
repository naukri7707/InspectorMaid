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

            new ComposerOf(this)
            {
                children = new VisualElement[]
                {
                    new ComposerOf(new PropertyField(m_ScriptProperty))
                    {
                        enabled = false,
                    }
                },
            };
        }
    }
}
