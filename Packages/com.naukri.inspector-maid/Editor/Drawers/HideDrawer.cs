using Naukri.InspectorMaid.Editor.Receivers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class HideDrawer : WidgetDrawerOf<HideAttribute>, IDrawMemeberReceiver
    {
        public void OnDrawMember(IWidget widget, VisualElement memberElement)
        {
            memberElement.style.display = DisplayStyle.None;
            memberElement.style.visibility = Visibility.Hidden;
        }
    }
}
