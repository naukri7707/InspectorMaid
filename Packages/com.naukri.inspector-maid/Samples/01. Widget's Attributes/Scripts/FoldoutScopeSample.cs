using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class FoldoutScopeSample : AttributeSampleBehaviour
    {
        [HelpBox("[FoldoutScope] allows you to create a scope that can be toggled visible by clicking the header.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [FoldoutScope("Help Infos")]
        [HelpBox("Some help info", HelpBoxMessageType.Info)]
        [HelpBox("Another help info", HelpBoxMessageType.Info)]
        [HelpBox("Some warning", HelpBoxMessageType.Warning)]
        [EndScope]
        [Target]
        public int sample1;

        [HelpBox("You can also change the default expand if you want.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 2
        [FoldoutScope("Help Infos", expend: true)]
        [HelpBox("Some help info", HelpBoxMessageType.Info)]
        [HelpBox("Another help info", HelpBoxMessageType.Info)]
        [HelpBox("Some warning", HelpBoxMessageType.Warning)]
        [EndScope]
        [Target]
        public int sample2;
    }
}
