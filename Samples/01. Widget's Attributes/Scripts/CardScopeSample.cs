using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class CardScopeSample : AttributeSampleBehaviour
    {
        [HelpBox(
@"[CardScope] will create a card style widget to wrap the content,
this is useful for highlighting some content.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [CardScope]
        [Target]
        [EndScope]
        public int Sample1;
    }
}
