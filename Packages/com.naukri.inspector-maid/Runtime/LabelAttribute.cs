using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class LabelAttribute : InspectorMaidBindableAttribute
    {
        public LabelAttribute() : this(string.Empty)
        { }

        public LabelAttribute(string label)
        {
            this.label = label;
        }

        public readonly string label;

        public bool useNicifyName = true;
    }
}
