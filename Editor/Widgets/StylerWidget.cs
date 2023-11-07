using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public abstract class StylerWidget : WidgetOf<StylerContext>
    {
        public abstract void OnStyling(IStyle style);

        public override StylerContext CreateContext() => new(this);

        internal override void OnContextAttached(StylerContext context)
        {
            var visualContext = context.GetAncestorContext<VisualContext>();
            visualContext.OnElementRendered += OnElementRendered;
        }

        protected virtual void OnElementRendered(VisualElement renderedElement) { }
    }
}
