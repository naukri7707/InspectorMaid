using Naukri.InspectorMaid.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Style
{
    public class FlexDirectionAttribute : StylerAttribute
    {
        public FlexDirectionAttribute(FlexDirection flexDirection)
        {
            this.flexDirection = flexDirection;
        }

        public readonly StyleEnum<FlexDirection> flexDirection;
    }
}
