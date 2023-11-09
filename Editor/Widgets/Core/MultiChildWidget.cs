using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Contexts.Core;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public abstract class MultiChildWidget : LogicWidget
    {
        public sealed override Context CreateContext() => new MultiChildContext(this);
    }
}
