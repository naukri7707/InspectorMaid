using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class LabelAttribute : BindableDrawerAttribute
    {
        public LabelAttribute(
            string label = "",
            bool useNicifyName = false,
            string binding = null,
            params object[] args
            ) : base(binding, args)
        {
            this.label = label;
            this.useNicifyName = useNicifyName;
        }

        public readonly string label;

        public readonly bool useNicifyName;
    }
}
