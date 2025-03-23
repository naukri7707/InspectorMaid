using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class DividerSample : AttributeSampleBehaviour
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

    [
    HelpBox("[Divider] can help you to separate your UI.", HelpBoxMessageType.Info),
    // Sample 1
    GroupScope("01. Divider", true),
        CardSlot(nameof(simpleDivider)),
    EndScope,
    // Sample 2
    GroupScope("02. Divider with text", true),
        CardSlot(nameof(textDivider)),
    EndScope,
    ]
    partial class DividerSample { }
}
