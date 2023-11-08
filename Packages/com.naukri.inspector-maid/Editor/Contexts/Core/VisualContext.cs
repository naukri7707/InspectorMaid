using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Contexts.Core
{
    public abstract class VisualContext : Context
    {
        protected VisualContext(VisualWidget widget)
        {
            this.widget = widget;
        }

        public VisualElement renderedElement;

        protected VisualWidget widget;

        public override IWidget Widget => widget;

        public VisualElement Build()
        {
            renderedElement = widget.Build(this);

            this.VisitChildReceivers<IStylingReceiver>((ctx, r) =>
            {
                r.OnStyling(ctx, renderedElement);
            });

            return renderedElement;
        }
    }
}
