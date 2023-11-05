using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class HideIfScopeSample : AttributeSampleBehaviour
    {
        [HelpBox(
@"[HideIfScope] will hide the scope if the binded value is 'true'.
This is helpful when you want to hide some widgets for some reason.", HelpBoxMessageType.Info)]
        public bool hide;

        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [HideIfScope(binding: nameof(hide))]
        public int hideTarget;

        [HelpBox("You can use [EndScope] to define the working scope of [HideIfScope].", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 2
        [HideIfScope(binding: nameof(hide))]
        [Button("Click me!", binding: nameof(MyMethod))]
        [EndScope] // EndScope close the scope of HideIfScope, so that the next widget (Target) will not be hide.
        public int hideUI;

        public void MyMethod()
        {
            Debug.Log("Hello world!");
        }
    }
}
