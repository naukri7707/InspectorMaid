using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class CardScopeSample : AttributeSampleBehaviour
    {
        // Sample 1
        [CardScope]
        [Target]
        [EndScope]
        public int cardScope;
    }

    [HelpBox(
    @"[CardScope] will create a card style widget to wrap the content,
this is useful for highlighting some content.", HelpBoxMessageType.Info)]
    // Sample 1
    [GroupScope("01. CardScope", true)]
    [CardSlot(nameof(cardScope))]
    [EndScope]
    partial class CardScopeSample { }
}
