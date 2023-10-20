using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public class MethodElement : VisualElement
    {
        public MethodElement(object target, MethodInfo info)
        {
            this.target = target;
            this.info = info;
        }

        private readonly MethodInfo info;

        private readonly object target;

        private string _label;

        [SuppressMessage("Style", "IDE1006")]
        public string label { get => _label; set => _label = value; }

        internal void Build()
        {
            OnBuild();
        }

        protected virtual void OnBuild()
        {
            // Todo: Add support for parameters
            AddToClassList(BaseField<object>.ussClassName);
            style.flexDirection = FlexDirection.Row;

            var labelElement = new Label(label);
            labelElement.AddToClassList(BaseField<object>.labelUssClassName);
            if (label == null)
            {
                AddToClassList(BaseField<object>.noLabelVariantUssClassName);
            }

            var box = new Box();
            box.style.backgroundColor = new Color(0, 0, 0, 0);
            box.style.flexGrow = 99;

            var button = new Button(() => info.Invoke(target, new object[0]))
            {
                text = "Invoke",
                focusable = false
            };
            button.style.width = 80;

            Add(labelElement);
            Add(box);
            Add(button);
        }
    }
}
