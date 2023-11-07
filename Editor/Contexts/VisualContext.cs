using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Widgets;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Contexts
{
    public class VisualContext : MultiChildContext
    {
        public VisualContext(VisualWidget widget)
        {
            this.widget = widget;
        }

        private readonly VisualWidget widget;

        private VisualElement renderedElement;

        public override IWidget Widget => widget;

        public event Action<VisualElement> OnElementRendered = re => { };

        public VisualElement Build()
        {
            renderedElement = widget.Build(this);
            OnElementRendered(renderedElement);
            return renderedElement;
        }
    }
}
