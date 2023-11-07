using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class DividerAttribute : WidgetAttribute
    {
        public DividerAttribute(string text = null)
        {
            this.text = text;
        }

        public readonly string text;
    }
}
