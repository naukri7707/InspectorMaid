using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class DividerDrawer : CustomDrawerOf<DividerAttribute>
    {
        public override void OnStart()
        {
            var divider = new Divider(attribute.text);
            decorator.Add(divider);
        }
    }
}
