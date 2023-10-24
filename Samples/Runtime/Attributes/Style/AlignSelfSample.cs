using Naukri.InspectorMaid.Style;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples
{
    public class AlignSelfSample : MonoBehaviour
    {
        [Size(width: 300), AlignSelf(Align.Center)]
        public string alignSelf;
    }
}
