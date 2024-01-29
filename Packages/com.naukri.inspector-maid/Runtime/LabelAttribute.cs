using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class LabelAttribute : ItemAttribute, IBindingDataProvider
    {
        public LabelAttribute(
            string text = "",
            string binding = null,
            object[] args = null
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
