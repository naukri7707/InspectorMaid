using Naukri.InspectorMaid.Style;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class HelpBoxSample : MonoBehaviour
    {
        [Margin(top: 20)]
        [HelpBox("Normal helpbox")]
        public int normal = 0;

        [Margin(top: 20)]
        [HelpBox("Helpbox with info", HelpBoxMessageType.Info)]
        public int info = 0;

        [Margin(top: 20)]
        [HelpBox("Normal helpbox", HelpBoxMessageType.Warning)]
        public int warning = 0;

        [Margin(top: 20)]
        [HelpBox("Helpbox with info", HelpBoxMessageType.Error)]
        public int error = 0;

        [Margin(top: 20)]
        [FlexDirection(FlexDirection.RowReverse), HelpBox("Change Position", HelpBoxMessageType.Info)]
        public int changeThePosition = 0;

        [Margin(top: 20)]
        [HelpBox("Specific Size", HelpBoxMessageType.Info), Size(width: "40%")]
        public int specificSize = 0;
    }
}
