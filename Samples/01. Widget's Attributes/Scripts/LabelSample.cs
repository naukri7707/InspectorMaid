using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class LabelSample : AttributeSampleBehaviour
    {
        [HelpBox(
@"[Label] will change lastest declared widget's first descendant label.
This is useful when we want to rename the target's prefix label.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [Target, Label("newLabel")]
        public int useLabel;

        [CardScope(color: kSectionBGColor)]
        // Sample 2
        [Target, Label("newLabelWithNicifyName", useNicifyName: true)]
        public int useLabelWithNicifyName;

        [HelpBox("You can also change target's label dynamically by binding.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 3
        [Target, Label(binding: nameof(bindingMessage))]
        public string bindingMessage = "change me!";

        // Sample 4
        // If you only use [Label],
        // it will implicitly reference the Member Widget (the container of all widgets of this member) and rename the target's first descendant label.
        // Because that MemberWidget doesn't have a label, it will rename the target's  prefix label.
        // So this is useful for cases where you don't want to generate a complex UI but want to simply rename the target prefix label.
        [Label("Use simply", useNicifyName: true)]
        public int simpleUse;
    }
}
