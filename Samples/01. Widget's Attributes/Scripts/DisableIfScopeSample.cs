using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox(@"[DisableIfScope] will disable the scope if the binded value is 'true'.
This is helpful when you want to make some widgets readonly for some reason.", HelpBoxMessageType.Info)]
    [Slot(nameof(disable))]
    [Divider("01. Disable Target")]
    [CardSlot(nameof(disableTarget))]
    [Divider("02. Disable Created Widget")]
    [HelpBox("You can use [EndScope] to define the working scope of [DisableIfScope].", HelpBoxMessageType.Info)]
    [CardSlot(nameof(disableUI))]
    public class DisableIfScopeSample : AttributeSampleBehaviour
    {
        public bool disable;

        // Sample 1
        [DisableIfScope(binding: nameof(disable))]
        public int disableTarget;

        // Sample 2
        [DisableIfScope(binding: nameof(disable))]
        [Button("Click me!", binding: nameof(HelloWorld))]
        [EndScope] // EndScope close the scope of DisableIfScope, so that the next widget (Target) will not be disabled.
        public int disableUI;

        public void HelloWorld()
        {
            Debug.Log("Hello world!");
        }
    }
}
