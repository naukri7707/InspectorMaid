using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class SlotAttribute : ScopeAttribute
    {
        public SlotAttribute(string template)
        {
            this.templateName = template;
        }

        public readonly string templateName;
    }
}
