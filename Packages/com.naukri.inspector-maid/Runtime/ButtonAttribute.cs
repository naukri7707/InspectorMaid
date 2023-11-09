using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class ButtonAttribute : ItemAttribute, IBindingDataProvider
    {
        public ButtonAttribute(
            string text = "",
            string binding = null,
            object[] args = null,
            bool setDirty = false
            )
        {
            this.text = text;
            this.binding = binding;
            this.args = args;
            this.setDirty = setDirty;
        }

        public readonly string text;

        public readonly bool setDirty;

        public object[] args { get; }

        public string binding { get; }
    }
}
