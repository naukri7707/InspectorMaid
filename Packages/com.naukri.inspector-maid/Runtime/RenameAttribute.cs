using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class RenameAttribute : StylerAttribute, IBindingDataProvider
    {
        public RenameAttribute(
            string text = "",
            string replaceText = null,
            float minWidth = float.NaN,
            bool useNicifyName = false,
            string binding = null,
            object[] args = null
            )
        {
            this.text = text;
            this.replaceText = replaceText;
            this.minWidth = minWidth;
            this.useNicifyName = useNicifyName;
            this.binding = binding;
            this.args = args;
        }

        public readonly string text;

        public readonly string replaceText;

        public readonly float minWidth;

        public readonly bool useNicifyName;

        public object[] args { get; }

        public string binding { get; }
    }
}
