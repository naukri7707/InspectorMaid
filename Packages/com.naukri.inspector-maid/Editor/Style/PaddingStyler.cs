using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Style;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Style
{
    public class PaddingStyler : CustomStylerOf<PaddingAttribute>
    {
        public override void OnStyling(IStyle style)
        {
            style.paddingTop = attribute.top;
            style.paddingRight = attribute.right;
            style.paddingBottom = attribute.bottom;
            style.paddingLeft = attribute.left;
        }
    }
}
