using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class ShowIfDrawer : CustomDrawerOf<ShowIfScopeAttribute>
    {
        public override void OnSceneGUI()
        {
            var show = GetBindingValue<bool>();

            if (show)
            {
                decorator.visible = true;
                decorator.style.height = StyleKeyword.Auto;
                decorator.style.width = StyleKeyword.Auto;
            }
            else
            {
                decorator.visible = false;
                decorator.style.height = 0;
                decorator.style.width = 0;
            }
        }
    }
}
