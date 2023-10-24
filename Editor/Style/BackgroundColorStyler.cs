using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Style;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Style
{
    public class BackgroundColorStyler : CustomStylerOf<BackgroundColorAttribute>
    {
        public override void OnStyling(IStyle style)
        {
            style.backgroundColor = attribute.backgroundColor;
        }
    }
}
