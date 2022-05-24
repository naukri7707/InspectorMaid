using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class HideIfScopeSample : MonoBehaviour
    {
        [HelpBox("[HideIfScope] will hide the scope if the binded value is 'true'.\r\nThis is helpful when you want to hide some element.", HelpBoxMessageType.Info)]
        public bool hide;

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [HideIfScope(binding: nameof(hide))]
        public int hideTarget;

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 2
        [HideIfScope(binding: nameof(hide))]
        [Button("Click me!", binding: nameof(MyMethod))]
        [EndScope] // EndScope is used to end the scope, so that the next element (Target) will not be disabled.
        public int hideUI;

        public void MyMethod()
        {
            Debug.Log("Hello world!");
        }
    }
}
