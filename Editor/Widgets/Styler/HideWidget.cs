using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public class HideWidget : StylerWidgetOf<HideAttribute>
    {
        public override void OnStyling(IBuildContext context, VisualElement stylingElement)
        {
            stylingElement.style.display = DisplayStyle.None;
            stylingElement.style.visibility = Visibility.Hidden;
        }
    }
}
