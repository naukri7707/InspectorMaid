using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public class ReadOnlyWidget : StylerWidgetOf<ReadOnlyAttribute>
    {
        public override void OnStyling(IBuildContext context, VisualElement stylingElement)
        {
            stylingElement.SetEnabled(false);
        }
    }
}
