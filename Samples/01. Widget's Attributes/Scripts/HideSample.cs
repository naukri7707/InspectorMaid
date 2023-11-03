using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class HideSample : AttributeSampleBehaviour
    {
        [HelpBox("[Hide] will not render anything, but hide the 'Target' element.", HelpBoxMessageType.Info)]
        [HelpBox("Unlike [HideIfScope], [Hide] only hide the 'Target' element, while [HideIfScope] hide the entire scope.", HelpBoxMessageType.Warning)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [Hide]
        public int myField;
    }
}
