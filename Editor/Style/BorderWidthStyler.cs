using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Style;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Style
{
    public class BorderWidthStyler : CustomStylerOf<BorderWidthAttribute>
    {
        public override void OnStyling(IStyle style)
        {
            style.borderTopWidth = attribute.top;
            style.borderRightWidth = attribute.right;
            style.borderBottomWidth = attribute.bottom;
            style.borderLeftWidth = attribute.left;
        }
    }
}
