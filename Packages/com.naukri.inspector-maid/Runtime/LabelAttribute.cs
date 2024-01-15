using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class LabelAttribute : StylerAttribute, IBindingDataProvider
    {
        public LabelAttribute(
            string label = "",
            string replaceText = null,
            float minWidth = float.NaN,
            bool useNicifyName = false,
            string binding = null,
            object[] args = null
            )
        {
            this.label = label;
            this.replaceText = replaceText;
            this.minWidth = minWidth;
            this.useNicifyName = useNicifyName;
            this.binding = binding;
            this.args = args;
        }

        public readonly string label;

        public readonly string replaceText;

        public readonly float minWidth;

        public readonly bool useNicifyName;

        public object[] args { get; }

        public string binding { get; }
    }
}
