using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class LabelSample : MonoBehaviour
    {
        [HelpBox("[Label] can change 'Target' prefix label.", HelpBoxMessageType.Info)]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [Label("newLabel")]
        public int useLabel;

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 2
        [Label("newLabelWithNicifyName", useNicifyName: true)]
        public int useLabelWithNicifyName;

        [HelpBox("You can also change the label of 'Target' dynamically by binding.", HelpBoxMessageType.Info)]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 3
        [Label(binding: nameof(bindingMessage))]
        public string bindingMessage = "change me!";
    }
}
