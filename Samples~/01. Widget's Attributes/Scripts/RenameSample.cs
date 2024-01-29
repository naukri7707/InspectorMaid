using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class RenameSample : AttributeSampleBehaviour
    {
        // Sample 1
        [Target, Rename("newLabel")]
        public int useLabel;

        [Target, Rename("newLabelWithNicifyName", useNicifyName: true)]
        public int useLabelWithNicifyName;

        // Sample 2
        [Target, Rename(binding: nameof(bindingMessage))]
        public string bindingMessage = "change me!";

        // Sample 3
        [Rename("Simply rename", useNicifyName: true)]
        public int renameTarget;

        // Sample 3
        [Rename("Min", replaceText: "X", minWidth: 30)]
        [Rename("Max", replaceText: "Y", minWidth: 30)]
        public Vector2 renameBySubString;
    }

    [
    HelpBox(@"[Rename] will change lastest widget's first descendant label.
This is useful when we want to rename the target's prefix label.", HelpBoxMessageType.Info),
    // Sample 1
    GroupScope("01. Label"),
        CardSlot(nameof(useLabel)),
        CardSlot(nameof(useLabelWithNicifyName)),
    EndScope,
    // Sample 2
    GroupScope("02. Rename with binding"),
        HelpBox("You can also change target's label dynamically by binding.", HelpBoxMessageType.Info),
        CardSlot(nameof(bindingMessage)),
    EndScope,
    // Sample 3
    GroupScope("03. Simpify trick"),
        HelpBox(@"If there is no widget before the styler, the styler will modify the [MemberWidget] (a simple container of all widgets in this member).
So if you don't have any other widget, and only want to change the prefix label of [Target], you can simply add [Label] to the member.", HelpBoxMessageType.Info),
        CardSlot(nameof(renameTarget)),
    EndScope,
    GroupScope("04. Rename By Sub String"),
        HelpBox(@"If the Label you want to rename is not the first label, you can use 'replaceText' to define the string to replace. In this mode, any string in a label that contains the specified substring will be replaced.", HelpBoxMessageType.Info),
        CardSlot(nameof(renameBySubString)),
    EndScope,
    ]
    partial class RenameSample { }
}
