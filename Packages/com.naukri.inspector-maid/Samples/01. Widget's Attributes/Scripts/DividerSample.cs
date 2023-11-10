using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox("[Divider] can help you to separate your UI.", HelpBoxMessageType.Info)]
    [Divider("01. Divider")]
    [CardSlot(nameof(simpleDivider))]
    [Divider("02. Divider with text")]
    [CardSlot(nameof(textDivider))]
    public class DividerSample : AttributeSampleBehaviour
    {
        // Sample 1
        [Target]
        [Divider]
        [HelpBox("My UI", HelpBoxMessageType.Info)]
        public int simpleDivider;

        // Sample 2
        [Target]
        [Divider("Text Divider")]
        [HelpBox("My UI", HelpBoxMessageType.Info)]
        public int textDivider;
    }
}
