using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox(@"[ShowIfScope] will hide the scope if the binded value is 'false'.
This is helpful when you want to hide some widgets for some reason.", HelpBoxMessageType.Info)]
    [Slot(nameof(show))]
    [Divider("01. Show Target")]
    [CardSlot(nameof(hideTarget))]
    [Divider("02. Show Created Widget")]
    [HelpBox("You can use [EndScope] to define the working scope of [ShowIfScope].", HelpBoxMessageType.Info)]
    [CardSlot(nameof(hideUI))]
    public class ShowIfScopeSample : AttributeSampleBehaviour
    {
        public bool show;

        // Sample 1
        [ShowIfScope(binding: nameof(show))]
        public int hideTarget;

        // Sample 2
        [ShowIfScope(binding: nameof(show))]
        [Button("Click me!", binding: nameof(HelloWorld))]
        [EndScope] // EndScope close the scope of ShowIfScope, so that the next widget (Target) will not be hide.
        public int hideUI;

        public void HelloWorld()
        {
            Debug.Log("Hello world!");
        }
    }
}
