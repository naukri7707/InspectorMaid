using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox(@"[Target] is a special attribute used to mark the location where the field, property or method widget should be drawn.
This is particularly useful when defining the target location or setting the target style.", HelpBoxMessageType.Info)]
    [Divider("01. Target")]
    [CardSlot(nameof(withoutTarget))]
    [CardSlot(nameof(withTarget))]
    public class TargetSample : AttributeSampleBehaviour
    {
        // Sample 1
        [HelpBox("'Helpbox' is currently positioned above 'Target'.")]
        public int withoutTarget = 0;

        // Sample 2
        [Target]
        [HelpBox("Due to the declaration of [Target] before [Helpbox], now the 'Helpbox' is positioned below 'Target'")]
        public int withTarget = 0;
    }
}
