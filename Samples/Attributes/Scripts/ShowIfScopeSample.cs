using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class ShowIfScopeSample : AttributeSampleBehaviour
    {
        [HelpBox(
@"[ShowIfScope] will hide the scope if the binded value is 'false'.
This is helpful when you want to hide some element.", HelpBoxMessageType.Info)]
        public bool show;

        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [ShowIfScope(binding: nameof(show))]
        public int hideTarget;

        [HelpBox("You can use [EndScope] to define the working scope of [ShowIfScope].", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 2
        [ShowIfScope(binding: nameof(show))]
        [Button("Click me!", binding: nameof(MyMethod))]
        [EndScope] // EndScope close the scope of ShowIfScope, so that the next widget (Target) will not be hide.
        public int hideUI;

        public void MyMethod()
        {
            Debug.Log("Hello world!");
        }
    }
}
