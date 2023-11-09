using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Contexts.Core;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public abstract class ItemWidget : VisualWidget
    {
        // We need to create multiChildContext because we need to store the style widget.
        public override VisualContext CreateContext() => new MultiChildVisualContext(this);
    }
}
