using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class DividerSample : MonoBehaviour
    {
        // Divider can help you to wrap your UI and add some custom styles.
        [HelpBox("[Divider] can help you to separate your UI.", HelpBoxMessageType.Info)]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [Target]
        [Divider]
        [HelpBox("My UI", HelpBoxMessageType.Info)]
        public int SimpleDivider;

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [Target]
        [Divider("Text Divider")]
        [HelpBox("My UI", HelpBoxMessageType.Info)]
        public int TextDivider;
    }
}
