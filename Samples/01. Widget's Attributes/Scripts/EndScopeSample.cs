using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class EndScopeSample : AttributeSampleBehaviour
    {
        [HelpBox("[EndScope] can close the lastest open scope, allowing you to add widgets to another scope.", HelpBoxMessageType.Info)]
        [HelpBox("Notice that [EndScope] is a logic widget, so it won't render anything.", HelpBoxMessageType.Warning)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [Target]
        [RowScope, Style(margin: "10 0", padding: "5", backgroundColor: "#606060")]
        [HelpBox("My Element in scope 1", HelpBoxMessageType.Info)]
        [HelpBox("My Element in scope 1", HelpBoxMessageType.Warning)]
        [EndScope]
        [RowScope, Style(margin: "10 0", padding: "5", backgroundColor: "#606060")]
        [HelpBox("My Element in scope 2", HelpBoxMessageType.Error)]
        [EndScope]
        public int Sample1;
    }
}
