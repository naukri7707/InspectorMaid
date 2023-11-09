using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class SlotAttribute : ItemAttribute
    {
        public SlotAttribute(string templateName)
            : this(
                  new[] { templateName }
                  )
        { }

        public SlotAttribute(params string[] templateNames)
        {
            this.templateNames = templateNames;
        }

        public readonly string[] templateNames;
    }
}
