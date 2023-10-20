using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class ElementLabelAttribute : InspectorMaidBindableAttribute
    {
        public ElementLabelAttribute() : this(string.Empty)
        { }

        public ElementLabelAttribute(string label)
        {
            this.label = label;
        }

        public readonly string label;

        public bool useNicifyName = true;
    }
}
