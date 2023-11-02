using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.Services;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class SlotDrawer : WidgetDrawerOf<SlotAttribute>, IAwakeReceiver
    {
        public void OnAwake(IWidget widget)
        {
            var templateService = TemplateService.Of(widget);
            var templateName = attribute.templateName;
            var cloned = templateService[templateName].Clone();

            cloned.Build();

            widget.Add(cloned);
        }
    }
}
