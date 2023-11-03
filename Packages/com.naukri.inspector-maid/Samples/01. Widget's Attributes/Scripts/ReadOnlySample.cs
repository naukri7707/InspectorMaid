using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class ReadOnlySample : AttributeSampleBehaviour
    {
        [HelpBox("[ReadOnly] will not render anything, but disable the 'Target' element.", HelpBoxMessageType.Info)]
        [HelpBox("Unlike [DisableIfScope], ReadOnly only disable the 'Target' element, while [DisableIfScope] disable the entire scope.", HelpBoxMessageType.Warning)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [ReadOnly]
        public int myField;
    }
}
