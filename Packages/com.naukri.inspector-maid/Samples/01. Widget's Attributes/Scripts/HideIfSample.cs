using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class HideIfSample : AttributeSampleBehaviour
    {
        // Sample 1
        public bool hide;

        [HideIf(nameof(hide))]
        public int hideIfTrue;

        // Sample 2
        public int value;

        [HideIf(nameof(value), 10, 20)]
        public int hideIfValueIs10Or20;

        // Sample 3
        public FlagEunm enumValue;

        [HideIf(nameof(enumValue), FlagEunm.A, FlagEunm.B, conditionLogic: ConditionLogic.Flag)]
        public int hideIfHasFlagAOrB;

        public string text = "";

        [HideIf(nameof(IsTextLengthGreaterThan5))]
        public int hideIfTextLengthGreaterThan5;

        [HideIf(nameof(IsTextContains), args: new object[] { "A" })] // send 'A' as argument
        public int hideIfTextContainsA;

        public bool IsTextLengthGreaterThan5()
        {
            return text.Length > 5;
        }

        public bool IsTextContains(string text)
        {
            return this.text.Contains(text);
        }
    }

    [HelpBox("[HideIf] operates similarly to [Hide], but you can decide when to hide the widget by binding.", HelpBoxMessageType.Info)]
    // Sample 1
    [GroupScope("01. Value condition")]
    [HelpBox("The condition will be true if the binding value is NOT the default value of type (e.g. false, 0, or null).", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(hide))]
    [Slot(nameof(hideIfTrue))]
    [EndScope, EndScope]
    // Sample 2
    [GroupScope("02. Value condition with target values")]
    [HelpBox("You can also define multiple target values, the condition will be true if the binding value equals any target.", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(value))]
    [Slot(nameof(hideIfValueIs10Or20))]
    [EndScope, EndScope]
    // Sample 3
    [GroupScope("03. Flag condition")]
    [HelpBox("You can also use Flag mode by specifying 'ConditionLogic.Flag', the condition will be true if the binding value has any target flag.", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(enumValue))]
    [Slot(nameof(hideIfHasFlagAOrB))]
    [EndScope, EndScope]
    // Sample 4
    [GroupScope("04. Condition by method")]
    [HelpBox("You can also bind a method to do more complex condition, use 'args' to pass arguments to the method.", HelpBoxMessageType.Info)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(text))]
    [Slot(nameof(hideIfTextLengthGreaterThan5))]
    [Slot(nameof(hideIfTextContainsA))]
    [EndScope, EndScope]
    partial class HideIfSample { }
}
