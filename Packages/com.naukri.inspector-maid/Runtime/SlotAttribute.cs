using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class SlotAttribute : ItemAttribute
    {
        public SlotAttribute(string templateName)
        {
            this.templateName = templateName;
        }

        public readonly string templateName;
    }
}
