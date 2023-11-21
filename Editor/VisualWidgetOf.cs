using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Core;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class VisualWidgetOf<TAttribute> : WidgetOf<TAttribute>, IWidgetProvider
        where TAttribute : VisualAttribute
    {
        public sealed override Context CreateContext() => new MultiChildContext(this);
    }
}
