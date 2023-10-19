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
            BuildElement();
        }

        private readonly MethodInfo info;

        private readonly object target;

        private Label labelElement = new Label();

        [SuppressMessage("Style", "IDE1006")]
        public string label { get => labelElement.text; set => labelElement.text = value; }

        protected virtual void BuildElement()
        {
            // Todo: Add support for parameters
            AddToClassList(BaseField<object>.ussClassName);
            style.flexDirection = FlexDirection.Row;

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
