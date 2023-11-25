using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class SlotSample : AttributeSampleBehaviour
    {
        // Sample 1
        public int myField;

        [CardScope]
        [Slot(nameof(myField))]
        [Target]
        [EndScope]
        public int sample1;

        // Sample 2
        [CardScope]
        [Slot(nameof(sample1))]
        [Target]
        [EndScope]
        public int sample2;

        // Sample 3
        [Template] // Because of [Template], this member won't be render.
        [Target]
        public int templatedField;

        [Slot(nameof(templatedField))] // But we can still display it through Slot.
        [Target]
        public int sample3;
    }

    [HelpBox(@"[Slot] can treat any member as a template and display its content in the Slot.
This is useful for wrapping multiple target together or displaying the same target in different places.", HelpBoxMessageType.Info)]
    // Sample 1
    [GroupScope("01. Slot", true)]
    [CardScope, Style(backgroundColor: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(myField))]
    [Slot(nameof(sample1))]
    [EndScope, EndScope]
    // Sample 2
    [GroupScope("02. Nested Slot", true)]
    [HelpBox("[Slot] supports nested structure, the nested Slot will be rendered together.", HelpBoxMessageType.Info)]
    [CardScope, Style(backgroundColor: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(sample2))]
    [EndScope, EndScope]
    // Sample 3
    [GroupScope("03. Template", true)]
    [HelpBox(@"[Template] is a logic widget, if you use [Template], the member will be treated as a template, so it won't be render unless you use [Slot].", HelpBoxMessageType.Info)]
    [CardScope, Style(backgroundColor: CardSlotAttribute.kDefaultBGColor)]
    // We don't need to render templatedField here, because membersWidget won't render widget with [Template] actually.
    // [Slot(nameof(templatedField))]
    [Slot(nameof(sample3))]
    [EndScope, EndScope]
    partial class SlotSample { }
}
