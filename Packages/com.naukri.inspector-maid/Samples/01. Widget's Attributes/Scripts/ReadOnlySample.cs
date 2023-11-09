using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class ReadOnlySample : AttributeSampleBehaviour
    {
        [HelpBox("[ReadOnly] will disable lastest declared widget.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        // Because [ReadOnly] is a styler, so we need add [Target] before it.
        // otherwise it will disable [CardScope].
        [Target, ReadOnly]
        public int sample1;

        // Sample 2
        // If you only use [ReadOnly],
        // it will implicitly reference the Member Widget (the container of all widgets of this member) and disable it.
        // This is useful for cases where you don't want to generate a complex UI but want to simply disable the target.
        [ReadOnly]
        public int sample2;
    }
}
