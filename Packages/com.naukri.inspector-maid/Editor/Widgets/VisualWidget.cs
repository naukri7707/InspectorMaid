using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public abstract class VisualWidget : WidgetOf<VisualContext>
    {
        public abstract VisualElement Build(IBuildContext context);

        public override VisualContext CreateContext() => new(this);
    }
}
