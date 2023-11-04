using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class ContainerScopeSample : AttributeSampleBehaviour
    {
        [HelpBox("[ContainerScope] can help you to wrap your UI and add some custom styles.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [Target]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#404040", flexDirection: nameof(FlexDirection.Row))]
        [HelpBox("My UI1", HelpBoxMessageType.Info), Style(flexGrow: "0.5")]
        [HelpBox("My UI2", HelpBoxMessageType.Warning), Style(flexGrow: "0.2")]
        [HelpBox("My UI3", HelpBoxMessageType.Error), Style(flexGrow: "0.3")]
        public int Sample1;
    }
}
