using Naukri.InspectorMaid.Editor.UIElements;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class DividerDrawer : WidgetDrawerOf<DividerAttribute>
    {
        public override void OnStart(IWidget widget)
        {
            var divider = new Divider(attribute.text);

            widget.Add(divider);
        }
    }
}
