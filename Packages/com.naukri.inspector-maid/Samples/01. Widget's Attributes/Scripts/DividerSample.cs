using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class DividerSample : AttributeSampleBehaviour
    {
        [HelpBox("[Divider] can help you to separate your UI.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [Target]
        [Divider]
        [HelpBox("My UI", HelpBoxMessageType.Info)]
        public int SimpleDivider;

        [CardScope(color: kSectionBGColor)]
        // Sample 2
        [Target]
        [Divider("Text Divider")]
        [HelpBox("My UI", HelpBoxMessageType.Info)]
        public int TextDivider;
    }
}
