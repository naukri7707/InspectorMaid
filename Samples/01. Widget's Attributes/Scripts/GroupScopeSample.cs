using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox("[GroupScope] allows you to create a scope that can be toggled visible by clicking the title.", HelpBoxMessageType.Info)]
    [Divider("01. Group")]
    [CardSlot(nameof(sample1))]
    [Divider("02. Expend by default")]
    [HelpBox("You can also change the default expand if you want.", HelpBoxMessageType.Info)]
    [CardSlot(nameof(sample2))]
    public class GroupScopeSample : AttributeSampleBehaviour
    {
        // Sample 1
        [GroupScope("Help Infos")]
        [HelpBox("Some help info", HelpBoxMessageType.Info)]
        [HelpBox("Another help info", HelpBoxMessageType.Info)]
        [HelpBox("Some warning", HelpBoxMessageType.Warning)]
        [EndScope]
        [Target]
        public int sample1;

        // Sample 2
        [GroupScope("Help Infos", expend: true)]
        [HelpBox("Some help info", HelpBoxMessageType.Info)]
        [HelpBox("Another help info", HelpBoxMessageType.Info)]
        [HelpBox("Some warning", HelpBoxMessageType.Warning)]
        [EndScope]
        [Target]
        public int sample2;
    }
}
