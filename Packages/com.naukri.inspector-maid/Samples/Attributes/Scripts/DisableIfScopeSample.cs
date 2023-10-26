using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class DisableIfScopeSample : MonoBehaviour
    {
        [HelpBox("[DisableIfScope] will disable the scope if the binded value is 'true'.\r\nThis is helpful when you want to make some element readonly.", HelpBoxMessageType.Info)]
        public bool disable;

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [DisableIfScope(binding: nameof(disable))]
        public int disableTarget;

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 2
        [DisableIfScope(binding: nameof(disable))]
        [Button("Click me!", binding: nameof(MyMethod))]
        [EndScope] // EndScope is used to end the scope, so that the next element (Target) will not be disabled.
        public int disableUI;

        public void MyMethod()
        {
            Debug.Log("Hello world!");
        }
    }
}
