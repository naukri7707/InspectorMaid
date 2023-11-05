using Naukri.InspectorMaid.Editor.Helpers;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public class PropertyElement : VisualElement
    {
        public PropertyElement(UObject target, PropertyInfo info)
        {
            this.target = target;
            this.info = info;
            label = ObjectNames.NicifyVariableName(info.Name);
        }

        private readonly PropertyInfo info;

        private readonly UObject target;

        private string _label;

        private BindableElement propertyElement;

        [SuppressMessage("Style", "IDE1006")]
        public string label { get => _label; set => _label = value; }

        internal void Build()
        {
            propertyElement = PropertyBuilder.Build(label, target, info);
            Add(propertyElement);
        }
    }
}
