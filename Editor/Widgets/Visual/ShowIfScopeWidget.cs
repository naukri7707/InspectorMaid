using Naukri.InspectorMaid.Editor.Extensions;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class ShowIfScopeWidget : IfScopeWidgetOf<ShowIfScopeAttribute>
    {
        protected override VisualElement CreateContainer() => new ShowIf();

        protected override void OnUpdateElement(VisualElement visualElement, bool condition)
        {
            visualElement.SetDisplay(condition);
        }

        private class ShowIf : VisualElement { }
    }
}
