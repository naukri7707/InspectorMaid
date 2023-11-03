using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class EndScopeSample : AttributeSampleBehaviour
    {
        [HelpBox("[EndScope] can close the latest open scope, allowing you to add elements to another scope.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [Target]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#404040")]
        [HelpBox("My Element in scope 1", HelpBoxMessageType.Info)]
        [HelpBox("My Element in scope 1", HelpBoxMessageType.Warning)]
        [EndScope]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#606060")]
        [HelpBox("My Element in scope 2", HelpBoxMessageType.Error)]
        [EndScope]
        public int Sample1;
    }
}
