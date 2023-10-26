using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class ButtonAttribute : ItemAttribute, IBindable
    {
        public ButtonAttribute(
            string text = "",
            string binding = null,
            params object[] args
            )
        {
            this.text = text;
            this.binding = binding;
            this.args = args;
        }

        public readonly string text;

        public object[] args { get; }

        public string binding { get; }
    }
}
