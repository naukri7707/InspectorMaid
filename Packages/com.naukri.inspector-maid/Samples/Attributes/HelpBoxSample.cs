using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class HelpBoxSample : MonoBehaviour
    {
        [HelpBox("Normal helpbox")]
        public int normal = 0;

        [HelpBox("Helpbox with info", HelpBoxMessageType.Info)]
        public int info = 0;

        [HelpBox("Normal helpbox", HelpBoxMessageType.Warning)]
        public int warning = 0;

        [HelpBox("Helpbox with info", HelpBoxMessageType.Error)]
        public int error = 0;

        [HelpBox("Change Position", HelpBoxMessageType.Info)]
        public int changeThePosition = 0;

        [HelpBox("Specific Size", HelpBoxMessageType.Info)]
        public int specificSize = 0;
    }
}
