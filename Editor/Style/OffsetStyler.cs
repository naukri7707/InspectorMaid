using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Style;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Style
{
    public class OffsetStyler : CustomStylerOf<OffsetAttribute>
    {
        public override void OnStyling(IStyle style)
        {
            style.top = attribute.top;
            style.right = attribute.right;
            style.bottom = attribute.bottom;
            style.left = attribute.left;
        }
    }
}
