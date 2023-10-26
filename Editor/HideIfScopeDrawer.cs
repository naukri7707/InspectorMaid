using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class HideIfScopeDrawer : CustomDrawerOf<HideIfScopeAttribute>
    {
        public override void OnSceneGUI()
        {
            var hide = GetBindingValue<bool>();

            if (hide)
            {
                decorator.style.display = DisplayStyle.None;
                decorator.style.visibility = Visibility.Hidden;
            }
            else
            {
                decorator.style.display = DisplayStyle.Flex;
                decorator.style.visibility = Visibility.Visible;
            }
        }
    }
}
