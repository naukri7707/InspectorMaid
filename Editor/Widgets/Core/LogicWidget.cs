using Naukri.InspectorMaid.Editor.Contexts.Core;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public abstract class LogicWidget : IWidget
    {
        public abstract Context CreateContext();
    }
}
