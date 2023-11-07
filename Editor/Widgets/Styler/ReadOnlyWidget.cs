using Naukri.InspectorMaid.Editor.Receivers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public class ReadOnlyWidget : StylerWidgetOf<ReadOnlyAttribute>, ITargetBuildedReceiver
    {
        public override void OnStyling(IStyle style)
        {
        }

        public void OnTargetBuilded(IBuildContext context, VisualElement targetElement)
        {
            targetElement.SetEnabled(false);
        }
    }
}
