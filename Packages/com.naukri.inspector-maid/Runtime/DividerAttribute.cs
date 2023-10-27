using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class DividerAttribute : ItemAttribute
    {
        public readonly string text;

        public DividerAttribute(string text = null)
        {
            this.text = text;
        }
    }
}
