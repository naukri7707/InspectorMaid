using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Style;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Style
{
    public class FlexDirectionStyler : CustomStylerOf<FlexDirectionAttribute>
    {
        public override void OnStyling(IStyle style)
        {
            style.flexDirection = attribute.flexDirection;
        }
    }
}
