using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Style;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Style
{
    public class BorderRadiusStyler : CustomStylerOf<BorderRadiusAttribute>
    {
        public override void OnStyling(IStyle style)
        {
            style.borderTopLeftRadius = attribute.topLeft;
            style.borderTopRightRadius = attribute.topRight;
            style.borderBottomLeftRadius = attribute.bottomLeft;
            style.borderBottomRightRadius = attribute.bottomRight;
        }
    }
}
