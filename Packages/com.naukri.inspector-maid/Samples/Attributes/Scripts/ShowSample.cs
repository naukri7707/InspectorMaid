using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class ShowSample : MonoBehaviour
    {
        [HelpBox("[Show] doesn't actually do anything, but you can use it to mark property and method which you wanna to dispaly.", HelpBoxMessageType.Info)]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [Show]
        public int MyProperty { get; set; }

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 2
        [Show]
        public void MyMethod()
        {
            Debug.Log("Hello world!");
        }
    }
}
