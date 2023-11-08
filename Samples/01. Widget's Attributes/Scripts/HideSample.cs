using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class HideSample : AttributeSampleBehaviour
    {
        [HelpBox("[Hide] will hide lastest declared widget.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        // Because [Hide] is a styler, so we need add [Target] before it.
        // otherwise it will disable [CardScope].
        [Target, Hide]
        public int sample1;

        // Sample 2
        // If you only use [Hide],
        // it will implicitly reference the Member Widget (the container of all widgets of this member) and hide it.
        // This is useful for cases where you don't want to generate a complex UI but want to simply hide the target.
        [Hide]
        public int sample2;
    }
}
