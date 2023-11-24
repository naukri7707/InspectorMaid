using Naukri.InspectorMaid.Editor.Extensions;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public class HideWidget : StylerWidgetOf<HideAttribute>
    {
        public override void OnStyling(IBuildContext context, VisualElement element)
        {
            element.SetDisplay(false);
        }
    }
}
