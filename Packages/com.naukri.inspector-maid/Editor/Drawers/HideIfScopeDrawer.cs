using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class HideIfScopeDrawer : WidgetDrawerOf<HideIfScopeAttribute>
    {
        public override void OnSceneGUI(IWidget widget)
        {
            var hide = widget.GetBindingValue<bool>();

            if (hide)
            {
                widget.style.display = DisplayStyle.None;
                widget.style.visibility = Visibility.Hidden;
            }
            else
            {
                widget.style.display = DisplayStyle.Flex;
                widget.style.visibility = Visibility.Visible;
            }
        }
    }
}
