using Naukri.InspectorMaid.Editor.Widgets.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class DisableIfScopeWidget : IfScopeWidgetOf<DisableIfScopeAttribute>
    {
        protected override VisualElement CreateContainer() => new DisableIf();

        protected override void OnUpdateElement(VisualElement container, bool condition)
        {
            container.SetEnabled(!condition);
        }

        private class DisableIf : VisualElement { }
    }
}
