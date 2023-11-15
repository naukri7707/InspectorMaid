using Naukri.InspectorMaid.Editor.Helpers;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public class PropertyElement : VisualElement
    {
        public PropertyElement(object target, PropertyInfo info, SerializedObject serializedObject)
        {
            this.target = target;
            this.info = info;
            this.serializedObject = serializedObject;
            label = ObjectNames.NicifyVariableName(info.Name);
        }

        private readonly PropertyInfo info;

        private readonly SerializedObject serializedObject;

        private readonly object target;

        private string _label;

        private BindableElement propertyElement;

        [SuppressMessage("Style", "IDE1006")]
        public string label { get => _label; set => _label = value; }

        internal void Build()
        {
            propertyElement = PropertyBuilder.Build(label, target, info, serializedObject);
            Add(propertyElement);
        }
    }
}
