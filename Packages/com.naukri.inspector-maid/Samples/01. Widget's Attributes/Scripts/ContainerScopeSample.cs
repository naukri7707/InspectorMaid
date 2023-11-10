using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class ContainerScopeSample : AttributeSampleBehaviour
    {
        [HelpBox("[ColumnScope] and [RowScope] can help you to wrapping your UI vertically or horizontally.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [Target]
        [ColumnScope, Style(margin: "10 0", padding: "5", backgroundColor: "#404040")]
        [HelpBox("My UI1", HelpBoxMessageType.Info)]
        [HelpBox("My UI2", HelpBoxMessageType.Warning)]
        [HelpBox("My UI3", HelpBoxMessageType.Error)]
        public int column;

        [CardScope(color: kSectionBGColor)]
        // Sample 2
        [Target]
        [RowScope, Style(margin: "10 0", padding: "5", backgroundColor: "#404040")]
        [HelpBox("My UI1", HelpBoxMessageType.Info), Style(flexGrow: "0.5")] // we can use grow to let element fill the remaining space
        [HelpBox("My UI2", HelpBoxMessageType.Warning), Style(flexGrow: "0.2")]
        [HelpBox("My UI3", HelpBoxMessageType.Error), Style(flexGrow: "0.3")]
        public int row;
    }
}
