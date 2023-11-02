using Naukri.InspectorMaid.Editor.Receivers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class ReadOnlyDrawer : WidgetDrawerOf<ReadOnlyAttribute>, IDrawMemeberReceiver
    {
        public void OnDrawMember(IWidget widget, VisualElement memberElement)
        {
            memberElement.SetEnabled(false);
        }
    }
}
