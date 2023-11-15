using Naukri.InspectorMaid.Editor.Widgets.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class EnableIfScopeWidget : IfScopeWidgetOf<EnableIfScopeAttribute>
    {
        protected override VisualElement CreateContainer() => new EnableIf();

        protected override void OnUpdateElement(VisualElement container, bool condition)
        {
            container.SetEnabled(condition);
        }

        private class EnableIf : VisualElement { }
    }
}
