using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox(
@"[CardScope] will create a card style widget to wrap the content,
this is useful for highlighting some content.", HelpBoxMessageType.Info)]
    [Divider("01. CardScope")]
    [CardSlot(nameof(cardScope))]
    public class CardScopeSample : AttributeSampleBehaviour
    {
        // Sample 1
        [CardScope]
        [Target]
        [EndScope]
        public int cardScope;
    }
}
