using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Style;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Style
{
    public class MarginStyler : CustomStylerOf<MarginAttribute>
    {
        public override void OnStyling(IStyle style)
        {
            style.marginTop = attribute.top;
            style.marginRight = attribute.right;
            style.marginBottom = attribute.bottom;
            style.marginLeft = attribute.left;
        }
    }
}
