using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox("[ColumnScope] and [RowScope] can help you to wrapping your UI vertically or horizontally.", HelpBoxMessageType.Info)]
    [Divider("01. Column")]
    [CardSlot(nameof(column))]
    [Divider("02. Row")]
    [CardSlot(nameof(row))]
    public class ContainerScopeSample : AttributeSampleBehaviour
    {
        // Sample 1
        [Target]
        [ColumnScope]
        [HelpBox("My UI1", HelpBoxMessageType.Info)]
        [HelpBox("My UI2", HelpBoxMessageType.Warning)]
        [HelpBox("My UI3", HelpBoxMessageType.Error)]
        public int column;

        // Sample 2
        [Target]
        [RowScope]
        [HelpBox("My UI1", HelpBoxMessageType.Info), Style(flexGrow: "1")] // we can use grow to let element fill the remaining space
        [HelpBox("My UI2", HelpBoxMessageType.Warning), Style(flexGrow: "1")]
        [HelpBox("My UI3", HelpBoxMessageType.Error), Style(flexGrow: "1")]
        public int row;
    }
}
