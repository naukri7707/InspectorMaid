using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class GroupScopeSample : AttributeSampleBehaviour
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

    [HelpBox("[GroupScope] allows you to create a scope that can be toggled visible by clicking the title.", HelpBoxMessageType.Info)]
    // Sample 1
    [GroupScope("01. Group", true)]
    [CardSlot(nameof(sample1))]
    [EndScope]
    // Sample 2
    [GroupScope("02. Expend by default", true)]
    [HelpBox("You can also change the default expand if you want.", HelpBoxMessageType.Info)]
    [CardSlot(nameof(sample2))]
    [EndScope]
    partial class GroupScopeSample { }
}
