using Naukri.InspectorMaid.Style;
using UnityEngine;

namespace Naukri.InspectorMaid.Samples
{
    public class BackgroundColorSample : MonoBehaviour
    {
        [Margin(all: 5)]
        [BackgroundColor("#FF0000")]
        public string hexColor;

        [Margin(all: 5)]
        [BackgroundColor("#FF0000AA")]
        public string hexColorWithAlpha;

        [Margin(all: 5)]
        [BackgroundColor("0,255,0")]
        public string rgbText;

        [Margin(all: 5)]
        [BackgroundColor("0,255,0,128")]
        public string rgbaText;
    }
}
