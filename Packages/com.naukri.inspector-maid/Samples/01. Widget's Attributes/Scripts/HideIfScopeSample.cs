using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox(@"[HideIfScope] will hide the scope if the binded value is 'true'.
This is helpful when you want to hide some widgets for some reason.", HelpBoxMessageType.Info)]
    [Slot(nameof(hide))]
    [Divider("01. Hide Target")]
    [CardSlot(nameof(hideTarget))]
    [Divider("02. Hide Created Widget")]
    [HelpBox("You can use [EndScope] to define the working scope of [HideIfScope].", HelpBoxMessageType.Info)]
    [CardSlot(nameof(hideUI))]
    public class HideIfScopeSample : AttributeSampleBehaviour
    {
        public bool hide;

        // Sample 1
        [HideIfScope(binding: nameof(hide))]
        public int hideTarget;

        // Sample 2
        [HideIfScope(binding: nameof(hide))]
        [Button("Click me!", binding: nameof(HelloWorld))]
        [EndScope] // EndScope close the scope of HideIfScope, so that the next widget (Target) will not be hide.
        public int hideUI;

        public void HelloWorld()
        {
            Debug.Log("Hello world!");
        }
    }
}
