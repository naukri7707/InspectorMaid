using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class TargetDrawer : WidgetDrawerOf<TargetAttribute>, IDrawMemeberReceiver
    {
        public void OnDrawMember(IWidget widget, VisualElement memberElement)
        {
            widget.Add(memberElement);

            if (memberElement is MethodElement methodElement)
            {
                methodElement.OnInvoke += widget.Repaint;
            }
        }
    }
}
