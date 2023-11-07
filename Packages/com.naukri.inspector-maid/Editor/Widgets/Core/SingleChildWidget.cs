using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Contexts.Core;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public class SingleChildWidget : Widget
    {
        public sealed override Context CreateContext() => new SingleChildContext(this);
    }
}
