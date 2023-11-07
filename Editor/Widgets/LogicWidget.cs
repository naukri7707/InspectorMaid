using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Widgets.Core;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public abstract class LogicWidget : WidgetOf<LogicContext>
    {
        public override LogicContext CreateContext() => new(this);
    }
}
