using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class DisableIfScopeSample : AttributeSampleBehaviour
    {
        [HelpBox(
@"[DisableIfScope] will disable the scope if the binded value is 'true'.
This is helpful when you want to make some element readonly.", HelpBoxMessageType.Info)]
        public bool disable;

        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [DisableIfScope(binding: nameof(disable))]
        public int disableTarget;

        [HelpBox("You can use [EndScope] to define the working scope of [DisableIfScope].", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 2
        [DisableIfScope(binding: nameof(disable))]
        [Button("Click me!", binding: nameof(MyMethod))]
        [EndScope] // EndScope close the scope of DisableIfScope, so that the next widget (Target) will not be disabled.
        public int disableUI;

        public void MyMethod()
        {
            Debug.Log("Hello world!");
        }
    }
}
