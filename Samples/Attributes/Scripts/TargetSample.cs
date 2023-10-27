using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class TargetSample : MonoBehaviour
    {
        [HelpBox(@"
[Target] is a special attribute used to mark the location where the field/property/method element should be drawn.
This is particularly useful when defining the target location or setting the target style.
", HelpBoxMessageType.Info)]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [HelpBox("'Helpbox' is currently positioned above 'Target'.")]
        public int withoutTarget = 0;

        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [Target]
        [HelpBox("Due to the declaration of [Target] before [Helpbox], now the 'Helpbox' is positioned below 'Target'")]
        public int withTarget = 0;
    }
}
