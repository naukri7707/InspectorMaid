using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class ReadOnlySample : MonoBehaviour
    {
        [HelpBox("[ReadOnly] will disable the 'Target' element.", HelpBoxMessageType.Info)]
        [HelpBox("Unlike [DisableIfScope], ReadOnly only disable the 'Target' element, while [DisableIfScope] disable the entire scope", HelpBoxMessageType.Warning)]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [ReadOnly]
        public int myField;
    }
}
