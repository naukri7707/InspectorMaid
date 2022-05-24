using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class ShowIfScopeDrawer : CustomDrawerOf<ShowIfScopeAttribute>
    {
        public override void OnSceneGUI()
        {
            var show = GetBindingValue<bool>();

            if (show)
            {
                decorator.style.display = DisplayStyle.Flex;
                decorator.style.visibility = Visibility.Visible;
            }
            else
            {
                decorator.style.display = DisplayStyle.None;
                decorator.style.visibility = Visibility.Hidden;
            }
        }
    }
}
