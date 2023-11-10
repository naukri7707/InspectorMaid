using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox(@"[EnableIfScope] will disable the scope if the binded value is 'false'.
This is helpful when you want to make some widgets readonly for some reason.", HelpBoxMessageType.Info)]
    [Slot(nameof(enable))]
    [Divider("01. Enable Target")]
    [CardSlot(nameof(disableTarget))]
    [Divider("02. Enable Created Widget")]
    [HelpBox("You can use [EndScope] to define the working scope of [EnableIfScope].", HelpBoxMessageType.Info)]
    [CardSlot(nameof(disableUI))]
    public class EnableIfScopeSample : AttributeSampleBehaviour
    {
        public bool enable;

        // Sample 1
        [EnableIfScope(binding: nameof(enable))]
        public int disableTarget;

        // Sample 2
        [EnableIfScope(binding: nameof(enable))]
        [Button("Click me!", binding: nameof(HelloWorld))]
        [EndScope] // EndScope close the scope of EnableIfScope, so that the next widget (Target) will not be disabled.
        public int disableUI;

        public void HelloWorld()
        {
            Debug.Log("Hello world!");
        }
    }
}
