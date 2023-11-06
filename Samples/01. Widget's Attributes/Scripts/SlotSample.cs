using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class SlotSample : AttributeSampleBehaviour
    {
        [HelpBox(
@"[Slot] can treat any member as a WidgetTree template and display its content in the Slot.
This is useful for wrapping multiple target together or displaying the same target in different places.", HelpBoxMessageType.Info)]

        [Hide]
        public int intro1;

        [CardScope]
        public int myField;

        // Sample 1
        [CardScope]
        [Target]
        [Divider("Slot")]
        [Slot(nameof(myField))]
        [EndScope]
        public int sample1;

        [HelpBox("[Slot] supports nested structure, the nested Slot will be rendered together", HelpBoxMessageType.Info)]
        [HelpBox(
@"In order to avoid the application crash due to too deep nesting, only 7 layers will be rendered by default.
You can change the maximum depth in InspectorMaidSetting.", HelpBoxMessageType.Warning)]
        [Hide]
        public int intro2;

        // Sample 2
        [CardScope]
        [Target]
        [Divider("Nested Slot")]
        [Slot(nameof(sample1))]
        [EndScope]
        public int sample2;

        [HelpBox(
@"[Template] is a logic Widget, if you use [Template],
the member will be treated as a WidgetTree template,
so it will not be rendered unless you use Slot", HelpBoxMessageType.Info)]
        [Hide]
        public int intro3;

        // Sample 3-1
        [CardScope]
        [Template] // Because of [Template], this member will not be rendered.
        [Target]
        [EndScope]
        public int sample3_1;

        // Sample 3-2
        [CardScope]
        [Slot(nameof(sample3_1))] // But we can still display it through Slot.
        [Target]
        [EndScope]
        public int sample3_2;
    }
}
