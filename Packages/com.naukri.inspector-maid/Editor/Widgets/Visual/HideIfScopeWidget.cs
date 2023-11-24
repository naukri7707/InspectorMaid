using Naukri.InspectorMaid.Editor.Extensions;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class HideIfScopeWidget : IfScopeWidgetOf<HideIfScopeAttribute>
    {
        protected override VisualElement CreateContainer() => new HideIf();

        protected override void OnUpdateElement(VisualElement container, bool condition)
        {
            container.SetDisplay(!condition);
        }

        private class HideIf : VisualElement { }
    }
}
