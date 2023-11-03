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
            var widgetTree = templateService[templateName].CreateWidget();

            widget.Add(widgetTree);
        }
    }
}
