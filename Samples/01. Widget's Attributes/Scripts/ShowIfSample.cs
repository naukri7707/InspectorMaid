using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class ShowIfSample : AttributeSampleBehaviour
    {
        // Sample 1
        public bool show;

        [ShowIf(nameof(show))]
        public int showIfTrue;

        // Sample 2
        public int value;

        [ShowIf(nameof(value), 10, 20)]
        public int showIfValueIs10Or20;

        // Sample 3
        public FlagEunm enumValue;

        [ShowIf(nameof(enumValue), FlagEunm.A, FlagEunm.B, conditionLogic: ConditionLogic.Flag)]
        public int showIfHasFlagAOrB;

        public string text = "";

        [ShowIf(nameof(IsTextLengthGreaterThan5))]
        public int showIfTextLengthGreaterThan5;

        [ShowIf(nameof(IsTextContains), args: new object[] { "A" })] // send 'A' as argument
        public int showIfTextContainsA;

        public bool IsTextLengthGreaterThan5()
        {
            return text.Length > 5;
        }

        public bool IsTextContains(string text)
        {
            return this.text.Contains(text);
        }
    }

    [HelpBox("[ShowIf] operates similarly to [Show], but you can decide when to show the widget by binding.", HelpBoxMessageType.Info)]
    // Sample 1
    [GroupScope("01. Value condition")]
    [HelpBox("The condition will be true if the binding value is NOT the default value of type (e.g. false, 0, or null).", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(show))]
    [Slot(nameof(showIfTrue))]
    [EndScope, EndScope]
    // Sample 2
    [GroupScope("02. Value condition with target values")]
    [HelpBox("You can also define multiple target values, the condition will be true if the binding value equals any target.", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(value))]
    [Slot(nameof(showIfValueIs10Or20))]
    [EndScope, EndScope]
    // Sample 3
    [GroupScope("03. Flag condition")]
    [HelpBox("You can also use Flag mode by specifying 'ConditionLogic.Flag', the condition will be true if the binding value has any target flag.", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(enumValue))]
    [Slot(nameof(showIfHasFlagAOrB))]
    [EndScope, EndScope]
    // Sample 4
    [GroupScope("04. Condition by method")]
    [HelpBox("You can also bind a method to do more complex condition, use 'args' to pass arguments to the method.", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(text))]
    [Slot(nameof(showIfTextLengthGreaterThan5))]
    [Slot(nameof(showIfTextContainsA))]
    [EndScope, EndScope]
    partial class ShowIfSample { }
}
