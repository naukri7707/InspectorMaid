using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class HideIfDrawer : CustomDrawerOf<HideIfScopeAttribute>
    {
        public override void OnSceneGUI()
        {
            var hide = GetBindingValue<bool>();

            if (hide)
            {
                decorator.visible = false;
                decorator.style.height = 0;
                decorator.style.width = 0;
            }
            else
            {
                decorator.visible = true;
                decorator.style.height = StyleKeyword.Auto;
                decorator.style.width = StyleKeyword.Auto;
            }
        }
    }
}
