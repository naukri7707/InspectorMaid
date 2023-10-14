using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class EnableDrawer : CustomDrawerOf<EnableAttribute>
    {
        public override VisualElement OnDrawDecorator(VisualElement child, EnableAttribute attribute, DrawerArgs args)
        {
            var container = new VisualElement();
            container.SetEnabled(true);

            container.Add(child);

            return child;
        }
    }
}
