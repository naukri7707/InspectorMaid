using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class OnChangedAttribute : ItemAttribute, IBindingDataProvider
    {
        public OnChangedAttribute(
            string binding = null,
            object[] args = null,
            bool setDirty = false
            )
        {
            this.binding = binding;
            this.args = args;
            this.setDirty = setDirty;
        }

        public bool setDirty;

        public object[] args { get; }

        public string binding { get; }
    }
}
