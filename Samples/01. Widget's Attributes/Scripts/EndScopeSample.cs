using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class EndScopeSample : AttributeSampleBehaviour
    {
        // Sample 1
        [Target]
        [RowScope, Style(margin: "5 0", padding: "5", backgroundColor: "#606060")]
        [HelpBox("My Element in scope 1", HelpBoxMessageType.Info)]
        [HelpBox("My Element in scope 1", HelpBoxMessageType.Warning)]
        [EndScope]
        [RowScope, Style(margin: "5 0", padding: "5", backgroundColor: "#606060")]
        [HelpBox("My Element in scope 2", HelpBoxMessageType.Error)]
        [EndScope]
        public int endScope;
    }

    [HelpBox("[EndScope] will close the lastest open scope, this can allow you to add widgets to another scope.", HelpBoxMessageType.Info)]
    [HelpBox("Notice that [EndScope] is a logic widget, so it won't render anything.", HelpBoxMessageType.Warning)]
    // Sample 1
    [GroupScope("01. EndScope", true)]
    [CardSlot(nameof(endScope))]
    [EndScope]
    partial class EndScopeSample { }
}
