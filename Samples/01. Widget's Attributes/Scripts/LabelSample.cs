using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class LabelSample : AttributeSampleBehaviour
    {
        [Label("My Label")]
        public int simple;

        [Label("My Label", binding: nameof(bindingWithString))]
        public string bindingWithString = "change me!";
    }

    [
        HelpBox("[Label] can show any text on the inspector.", HelpBoxMessageType.Info),
        // Sample 1
        GroupScope("01. Label", true),
            CardSlot(nameof(simple)),
        EndScope,
        // Sample 2
        GroupScope("02. Label with binding", true),
            HelpBox("[Label] can also use binding to show dynamic text.", HelpBoxMessageType.Info),
            CardSlot(nameof(bindingWithString)),
        EndScope,
    ]
    partial class LabelSample { }
}
