using Naukri.InspectorMaid.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Style
{

    public class AlignSelfAttribute : StylerAttribute
    {
        public AlignSelfAttribute(Align alignSelf)
        {
            this.alignSelf = alignSelf;
        }

        public readonly StyleEnum<Align> alignSelf;
    }
}
