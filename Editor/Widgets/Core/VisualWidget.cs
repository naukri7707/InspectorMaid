using Naukri.InspectorMaid.Editor.Contexts.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public abstract class VisualWidget : IWidget
    {
        public abstract VisualContext CreateContext();

        public abstract VisualElement Build(IBuildContext context);

        Context IWidget.CreateContext() => CreateContext();
    }
}
