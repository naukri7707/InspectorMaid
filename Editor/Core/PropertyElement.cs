using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    public class PropertyElement : VisualElement
    {
        public PropertyElement(string label, UObject target, PropertyInfo info)
        {
            this.label = label;
            this.target = target;
            this.info = info;
        }

        private readonly PropertyInfo info;

        private readonly UObject target;

        private string _label;

        private BindableElement bindableElement;

        [SuppressMessage("Style", "IDE1006")]
        public string label { get => _label; set => _label = value; }

        internal void Build()
        {
            bindableElement = PropertyBuilder.Build(label, target, info);
            Add(bindableElement);
        }
    }
}
