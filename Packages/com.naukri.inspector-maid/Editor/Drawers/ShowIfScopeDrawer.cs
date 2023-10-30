using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class ShowIfScopeDrawer : WidgetDrawerOf<ShowIfScopeAttribute>
    {
        public override void OnSceneGUI(IWidget widget)
        {
            var show = widget.GetBindingValue<bool>();

            if (show)
            {
                widget.style.display = DisplayStyle.Flex;
                widget.style.visibility = Visibility.Visible;
            }
            else
            {
                widget.style.display = DisplayStyle.None;
                widget.style.visibility = Visibility.Hidden;
            }
        }
    }
}
