using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Style;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Style
{
    public class AlignSelfStyler : CustomStylerOf<AlignSelfAttribute>
    {
        public override void OnStyling(IStyle style)
        {
            style.alignSelf = attribute.alignSelf;
        }
    }
}
