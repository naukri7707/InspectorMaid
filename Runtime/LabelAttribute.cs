using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class LabelAttribute : StylerAttribute, IBindingDataProvider
    {
        public LabelAttribute(
            string label = "",
            bool useNicifyName = false,
            string binding = null,
            params object[] args
            )
        {
            this.label = label;
            this.useNicifyName = useNicifyName;
            this.binding = binding;
            this.args = args;
        }

        public readonly string label;

        public readonly bool useNicifyName;

        public object[] args { get; }

        public string binding { get; }
    }
}
