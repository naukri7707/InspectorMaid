using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class HideDrawer : CustomDrawerOf<HideAttribute>
    {
        public override VisualElement OnDrawDecorator(VisualElement child, HideAttribute attribute, DrawerArgs args)
        {
            return new VisualElement();
        }
    }
}
