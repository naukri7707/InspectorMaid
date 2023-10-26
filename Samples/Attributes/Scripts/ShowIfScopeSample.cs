using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class ShowIfScopeSample : MonoBehaviour
    {
        [HelpBox("[ShowIfScope] will hide the scope if the binded value is 'false'.\r\nThis is helpful when you want to hide some element.", HelpBoxMessageType.Info)]
        public bool show;

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [ShowIfScope(binding: nameof(show))]
        public int hideTarget;

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 2
        [ShowIfScope(binding: nameof(show))]
        [Button("Click me!", binding: nameof(MyMethod))]
        [EndScope] // EndScope is used to end the scope, so that the next element (Target) will not be disabled.
        public int hideUI;

        public void MyMethod()
        {
            Debug.Log("Hello world!");
        }
    }
}
