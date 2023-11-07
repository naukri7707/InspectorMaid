using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class SlotAttribute : WidgetAttribute
    {
        public SlotAttribute(string template)
        {
            this.templateName = template;
        }

        public readonly string templateName;
    }
}
