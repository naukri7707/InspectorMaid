using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class DisableDrawer : CustomDrawerOf<DisableAttribute>
    {
        public override VisualElement OnDrawDecorator(VisualElement child, DisableAttribute attribute, DrawerArgs args)
        {
            var container = new VisualElement();
            container.SetEnabled(false);

            container.Add(child);

            return child;
        }
    }
}
