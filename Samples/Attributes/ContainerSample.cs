using Naukri.InspectorMaid.Style;
using UnityEngine;

namespace Naukri.InspectorMaid.Samples
{
    public class ContainerSample : MonoBehaviour
    {
        [Padding(all: 20), BackgroundColor("#FF0000"), Container]
        [Padding(all: 10), BackgroundColor("#00FF00")]
        public int myField;
    }
}
