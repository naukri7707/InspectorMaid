using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Widgets;
using Naukri.InspectorMaid.Editor.Widgets.Core;

namespace Naukri.InspectorMaid.Editor.Contexts
{
    public class StylerContext : NoneChildContext
    {
        public StylerContext(StylerWidget widget)
        {
            this.widget = widget;
        }

        private readonly StylerWidget widget;

        public override IWidget Widget => widget;
    }
}
