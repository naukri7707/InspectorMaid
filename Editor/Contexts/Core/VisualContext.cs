using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.Widgets.Core;
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
            VisitChildContexts(ctx =>
            {
                if (ctx.Widget is IParentBuildedReceiver reciver)
                {
                    reciver.OnParentBuilded(ctx);
                }
            });

            return renderedElement;
        }
    }
}
