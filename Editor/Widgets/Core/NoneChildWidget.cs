using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Contexts.Core;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public class NoneChildWidget : LogicWidget
    {
        public sealed override Context CreateContext() => new NoneChildContext(this);
    }
}
