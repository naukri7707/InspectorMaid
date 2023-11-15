using Naukri.InspectorMaid.Editor.Widgets.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class HideIfScopeWidget : IfScopeWidgetOf<HideIfScopeAttribute>
    {
        protected override VisualElement CreateContainer() => new HideIf();

        protected override void OnUpdateElement(VisualElement container, bool condition)
        {
            if (condition)
            {
                container.style.display = DisplayStyle.None;
                container.style.visibility = Visibility.Hidden;
            }
            else
            {
                container.style.display = DisplayStyle.Flex;
                container.style.visibility = Visibility.Visible;
            }
        }

        private class HideIf : VisualElement { }
    }
}
