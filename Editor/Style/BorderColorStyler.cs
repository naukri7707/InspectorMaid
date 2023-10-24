using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Style;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Style
{
    public class BorderColorStyler : CustomStylerOf<BorderColorAttribute>
    {
        public override void OnStyling(IStyle style)
        {
            style.borderTopColor = attribute.top;
            style.borderRightColor = attribute.right;
            style.borderBottomColor = attribute.bottom;
            style.borderLeftColor = attribute.left;
        }
    }
}
