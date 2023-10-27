using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class HelpBoxSample : MonoBehaviour
    {
        [HelpBox("[HelpBox] will draw a Box with text and icon,\r\nThis is helpful when you want to show some information on the inspector like error message or notice.", HelpBoxMessageType.Info)]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [HelpBox("Normal helpbox")]
        public int normal = 0;

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 2
        [HelpBox("Helpbox with info icon", HelpBoxMessageType.Info)]
        public int info = 0;

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 3
        [HelpBox("Helpbox with warning icon", HelpBoxMessageType.Warning)]
        public int warning = 0;

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 4
        [HelpBox("Helpbox with error icon", HelpBoxMessageType.Error)]
        public int error = 0;

        [HelpBox("You can also change the content of HelpBox dynamically by binding.", HelpBoxMessageType.Info)]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 5
        // You can also change the content of HelpBox dynamically by binding.
        [HelpBox(binding: nameof(bindingMessage))]
        public string bindingMessage = "change me!";
    }
}
