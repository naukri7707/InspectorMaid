using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public class MethodBuilder
    {
        public MethodBuilder(object target, MethodInfo info, string label)
        {
            this.target = target;
            this.info = info;
            args = new Args()
            {
                Label = label
            };
        }

        public readonly Args args;

        private readonly MethodInfo info;

        private readonly object target;

        internal VisualElement Build()
        {
            // Todo: Add support for parameters
            var container = new VisualElement();
            container.AddToClassList(BaseField<object>.ussClassName);
            container.style.flexDirection = FlexDirection.Row;

            var label = new Label(args.Label);
            label.AddToClassList(BaseField<object>.labelUssClassName);
            if (args.Label == null)
            {
                container.AddToClassList(BaseField<object>.noLabelVariantUssClassName);
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

            container.Add(label);
            container.Add(box);
            container.Add(button);

            return container;
        }

        public class Args
        {
            public bool Enable { get; set; }

            public string Label { get; set; }
        }
    }
}
