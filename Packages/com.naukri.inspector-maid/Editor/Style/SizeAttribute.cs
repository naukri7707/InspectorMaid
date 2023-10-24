using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Style;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Style
{
    public class SizeStyler : CustomStylerOf<SizeAttribute>
    {
        public override void OnStyling(IStyle style)
        {
            style.width = attribute.width;
            style.height = attribute.height;
            style.minWidth = attribute.minWidth;
            style.minHeight = attribute.minHeight;
            style.maxWidth = attribute.maxWidth;
            style.maxHeight = attribute.maxHeight;
        }
    }
}
