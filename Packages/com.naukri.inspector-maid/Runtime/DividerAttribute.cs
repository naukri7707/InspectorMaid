using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class DividerAttribute : ItemAttribute
    {
        public DividerAttribute(string text = null)
        {
            this.text = text;
        }

        public readonly string text;
    }
}
