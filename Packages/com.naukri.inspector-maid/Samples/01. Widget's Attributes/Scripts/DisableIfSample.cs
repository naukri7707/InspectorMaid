using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class DisableIfSample : AttributeSampleBehaviour
    {
        // Sample 1
        public bool disable;

        [DisableIf(nameof(disable))]
        public int disableIfTrue;

        // Sample 2
        public int value;

        [DisableIf(nameof(value), 10, 20)]
        public int disableIfValueIs10Or20;

        // Sample 3
        public FlagEunm enumValue;

        [DisableIf(nameof(enumValue), FlagEunm.A, FlagEunm.B, conditionLogic: ConditionLogic.Flag)]
        public int disableIfHasFlagAOrB;

        public string text = "";

        [DisableIf(nameof(IsTextLengthGreaterThan5))]
        public int disableIfTextLengthGreaterThan5;

        [DisableIf(nameof(IsTextContains), args: new object[] { "A" })] // send 'A' as argument
        public int disableIfTextContainsA;

        public bool IsTextLengthGreaterThan5()
        {
            return text.Length > 5;
        }

        public bool IsTextContains(string text)
        {
            return this.text.Contains(text);
        }
    }

    [HelpBox("[DisableIf] operates similarly to [ReadOnly], but you can decide when to disable the widget by binding.", HelpBoxMessageType.Info)]
    // Sample 1
    [GroupScope("01. Value condition")]
    [HelpBox("The condition will be true if the binding value is NOT the default value of type (e.g. false, 0, or null).", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(disable))]
    [Slot(nameof(disableIfTrue))]
    [EndScope, EndScope]
    // Sample 2
    [GroupScope("02. Value condition with target values")]
    [HelpBox("You can also define multiple target values, the condition will be true if the binding value equals any target.", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(value))]
    [Slot(nameof(disableIfValueIs10Or20))]
    [EndScope, EndScope]
    // Sample 3
    [GroupScope("03. Flag condition")]
    [HelpBox("You can also use Flag mode by specifying 'ConditionLogic.Flag', the condition will be true if the binding value has any target flag.", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(enumValue))]
    [Slot(nameof(disableIfHasFlagAOrB))]
    [EndScope, EndScope]
    // Sample 4
    [GroupScope("04. Condition by method")]
    [HelpBox("You can also bind a method to do more complex condition, use 'args' to pass arguments to the method.", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(text))]
    [Slot(nameof(disableIfTextLengthGreaterThan5))]
    [Slot(nameof(disableIfTextContainsA))]
    [EndScope, EndScope]
    partial class DisableIfSample { }
}
