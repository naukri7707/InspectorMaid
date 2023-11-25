using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class EnableIfSample : AttributeSampleBehaviour
    {
        // Sample 1
        public bool enable;

        [EnableIf(nameof(enable))]
        public int enableIfTrue;

        // Sample 2
        public int value;

        [EnableIf(nameof(value), 10, 20)]
        public int enableIfValueIs10Or20;

        // Sample 3
        public FlagEunm enumValue;

        [EnableIf(nameof(enumValue), FlagEunm.A, FlagEunm.B, conditionLogic: ConditionLogic.Flag)]
        public int enableIfHasFlagAOrB;

        public string text = "";

        [EnableIf(nameof(IsTextLengthGreaterThan5))]
        public int enableIfTextLengthGreaterThan5;

        [EnableIf(nameof(IsTextContains), args: new object[] { "A" })] // send 'A' as argument
        public int enableIfTextContainsA;

        public bool IsTextLengthGreaterThan5()
        {
            return text.Length > 5;
        }

        public bool IsTextContains(string text)
        {
            return this.text.Contains(text);
        }
    }

    [HelpBox("[EnableIf] operates similarly to [ReadOnly], but you can decide when to enable the widget by binding.", HelpBoxMessageType.Info)]
    // Sample 1
    [GroupScope("01. Value condition")]
    [HelpBox("The condition will be true if the binding value is NOT the default value of type (e.g. false, 0, or null).", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(enable))]
    [Slot(nameof(enableIfTrue))]
    [EndScope, EndScope]
    // Sample 2
    [GroupScope("02. Value condition with target values")]
    [HelpBox("You can also define multiple target values, the condition will be true if the binding value equals any target.", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(value))]
    [Slot(nameof(enableIfValueIs10Or20))]
    [EndScope, EndScope]
    // Sample 3
    [GroupScope("03. Flag condition")]
    [HelpBox("You can also use Flag mode by specifying 'ConditionLogic.Flag', the condition will be true if the binding value has any target flag.", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(enumValue))]
    [Slot(nameof(enableIfHasFlagAOrB))]
    [EndScope, EndScope]
    // Sample 4
    [GroupScope("04. Condition by method")]
    [HelpBox("You can also bind a method to do more complex condition, use 'args' to pass arguments to the method.", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(text))]
    [Slot(nameof(enableIfTextLengthGreaterThan5))]
    [Slot(nameof(enableIfTextContainsA))]
    [EndScope, EndScope]
    partial class EnableIfSample { }
}
