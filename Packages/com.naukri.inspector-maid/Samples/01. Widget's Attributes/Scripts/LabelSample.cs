using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox(@"[Label] will change lastest declared widget's first descendant label.
This is useful when we want to rename the target's prefix label.", HelpBoxMessageType.Info)]
    [Divider("01. Label")]
    [CardSlot(nameof(useLabel))]
    [CardSlot(nameof(useLabelWithNicifyName))]
    [Divider("02. Label with binding")]
    [HelpBox("You can also change target's label dynamically by binding.", HelpBoxMessageType.Info)]
    [CardSlot(nameof(bindingMessage))]
    [Divider("03. Simpify trick")]
    [HelpBox(@"If there is no widget before the styler, the styler will modify the [MemberWidget] (a simple container of all widgets of this member).
So if you don't have any other widget, and only want to change the prefix label of [Target], you can simply add [Label] to the member.", HelpBoxMessageType.Info)]
    [CardSlot(nameof(renameTarget))]
    public class LabelSample : AttributeSampleBehaviour
    {
        // Sample 1
        [Target, Label("newLabel")]
        public int useLabel;

        [Target, Label("newLabelWithNicifyName", useNicifyName: true)]
        public int useLabelWithNicifyName;

        // Sample 2
        [Target, Label(binding: nameof(bindingMessage))]
        public string bindingMessage = "change me!";

        // Sample 3
        [Label("Simply rename", useNicifyName: true)]
        public int renameTarget;
    }
}
