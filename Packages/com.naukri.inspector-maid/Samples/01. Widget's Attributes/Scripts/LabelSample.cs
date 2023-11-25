using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class LabelSample : AttributeSampleBehaviour
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

    [
    HelpBox(@"[Label] will change lastest widget's first descendant label.
This is useful when we want to rename the target's prefix label.", HelpBoxMessageType.Info),
    // Sample 1
    GroupScope("01. Label"),
        CardSlot(nameof(useLabel)),
        CardSlot(nameof(useLabelWithNicifyName)),
    EndScope,
    // Sample 2
    GroupScope("02. Label with binding"),
        HelpBox("You can also change target's label dynamically by binding.", HelpBoxMessageType.Info),
        CardSlot(nameof(bindingMessage)),
    EndScope,
    // Sample 3
    GroupScope("03. Simpify trick"),
        HelpBox(@"If there is no widget before the styler, the styler will modify the [MemberWidget] (a simple container of all widgets in this member).
So if you don't have any other widget, and only want to change the prefix label of [Target], you can simply add [Label] to the member.", HelpBoxMessageType.Info),
        CardSlot(nameof(renameTarget)),
    EndScope,
    ]
    partial class LabelSample { }
}
