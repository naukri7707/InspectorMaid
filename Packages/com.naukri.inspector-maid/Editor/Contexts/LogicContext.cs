using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Widgets;
using Naukri.InspectorMaid.Editor.Widgets.Core;

namespace Naukri.InspectorMaid.Editor.Contexts
{
    public class LogicContext : SingleChildContext
    {
        public LogicContext(LogicWidget widget)
        {
            this.widget = widget;
        }

        private readonly LogicWidget widget;

        public override IWidget Widget => widget;
    }
}
