using Naukri.InspectorMaid.Style;
using UnityEngine;

namespace Naukri.InspectorMaid.Samples
{
    public class SizeSample : MonoBehaviour
    {
        [Size(width: 250)]
        public string width;

        [Size(height: 30)]
        public string height;

        [Size(minWidth: 400)]
        public string minWidth;

        [Size(maxWidth: 450)]
        public string maxWidth;

        [Size(minHeight: 40)]
        public string minHeight;

        [Size(maxHeight: 15)]
        public string maxHeight;
    }
}
