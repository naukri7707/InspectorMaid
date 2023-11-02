using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class TemplateAttribute : WidgetAttribute
    {
        public TemplateAttribute(string name = null, bool showTemplate = false)
        {
            this.name = name;
            this.showTemplate = showTemplate;
        }

        public readonly string name;

        public readonly bool showTemplate;
    }
}
