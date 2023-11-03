using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class LabelSample : AttributeSampleBehaviour
    {
        [HelpBox("[Label] will not render anything, but can change 'Target' prefix label.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [Label("newLabel")]
        public int useLabel;

        [CardScope(color: kSectionBGColor)]
        // Sample 2
        [Label("newLabelWithNicifyName", useNicifyName: true)]
        public int useLabelWithNicifyName;

        [HelpBox("You can also change the label of 'Target' dynamically by binding.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 3
        [Label(binding: nameof(bindingMessage))]
        public string bindingMessage = "change me!";
    }
}
