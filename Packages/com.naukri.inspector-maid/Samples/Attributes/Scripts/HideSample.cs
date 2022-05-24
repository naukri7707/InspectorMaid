using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class HideSample : MonoBehaviour
    {
        [HelpBox("[Hide] will hide the 'Target' element.", HelpBoxMessageType.Info)]
        [HelpBox("Unlike [HideIfScope], [Hide] only hide the 'Target' element, while [HideIfScope] hide the entire scope", HelpBoxMessageType.Warning)]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [Hide]
        public int myField;
    }
}
