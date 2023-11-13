using Naukri.InspectorMaid.Editor.Widgets.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class EnableIfScopeWidget : IfScopeWidgetOf<EnableIfScopeAttribute>
    {
        protected override void OnUpdateElement(VisualElement visualElement, bool condition)
        {
            visualElement.SetEnabled(condition);
        }
    }
}
