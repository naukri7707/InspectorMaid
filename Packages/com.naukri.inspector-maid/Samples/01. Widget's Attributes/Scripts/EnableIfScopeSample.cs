using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class EnableIfScopeSample : AttributeSampleBehaviour
    {
        [HelpBox(
@"[EnableIfScope] will disable the scope if the binded value is 'false'.
This is helpful when you want to make some element readonly.", HelpBoxMessageType.Info)]
        public bool enable;

        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [EnableIfScope(binding: nameof(enable))]
        public int disableTarget;

        [HelpBox("You can use [EndScope] to define the working scope of [EnableIfScope].", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 2
        [EnableIfScope(binding: nameof(enable))]
        [Button("Click me!", binding: nameof(MyMethod))]
        [EndScope] // EndScope close the scope of EnableIfScope, so that the next widget (Target) will not be disabled.
        public int disableUI;

        public void MyMethod()
        {
            Debug.Log("Hello world!");
        }
    }
}
