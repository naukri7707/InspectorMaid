using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class HelpBoxSample : AttributeSampleBehaviour
    {
        // Sample 1
        [HelpBox("Normal helpbox")]
        public int normal = 0;

        [HelpBox("Helpbox with info icon", HelpBoxMessageType.Info)]
        public int info = 0;

        [HelpBox("Helpbox with warning icon", HelpBoxMessageType.Warning)]
        public int warning = 0;

        [HelpBox("Helpbox with error icon", HelpBoxMessageType.Error)]
        public int error = 0;

        // Sample 2
        // You can also change the content of HelpBox dynamically by binding.
        [HelpBox(binding: nameof(bindingMessage))]
        public string bindingMessage = "change me!";
    }

    [
    HelpBox(@"[HelpBox] will draw a Box with text and icon,
This is helpful when you want to show some information on the inspector like error message or notice.", HelpBoxMessageType.Info),
    // Sample 1
    GroupScope("01. HelpBoxs", true),
        CardSlot(nameof(normal)),
        CardSlot(nameof(info)),
        CardSlot(nameof(warning)),
        CardSlot(nameof(error)),
    EndScope,
    GroupScope("02. Binding message", true),
        HelpBox("You can also change the content of HelpBox dynamically by binding.", HelpBoxMessageType.Info),
        CardSlot(nameof(bindingMessage)),
    EndScope,
    ]
    partial class HelpBoxSample { }
}
