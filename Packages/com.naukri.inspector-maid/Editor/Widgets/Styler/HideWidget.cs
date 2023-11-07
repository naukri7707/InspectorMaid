using Naukri.InspectorMaid.Editor.Receivers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public class HideWidget : StylerWidgetOf<HideAttribute>, ITargetBuildedReceiver
    {
        public override void OnStyling(IStyle style)
        {
        }

        public void OnTargetBuilded(IBuildContext context, VisualElement targetElement)
        {
            targetElement.style.display = DisplayStyle.None;
            targetElement.style.visibility = Visibility.Hidden;
        }
    }
}
