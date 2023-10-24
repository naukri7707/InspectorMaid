using Naukri.InspectorMaid.Style;
using UnityEngine;

namespace Naukri.InspectorMaid.Samples
{
    public class BorderColorSample : MonoBehaviour
    {
        [Margin(all: 5)]
        [BorderWidth(2), BorderColor("#FF0000")]
        public string hexColor;

        [Margin(all: 5)]
        [BorderWidth(all: 2), BorderColor("#FF0000AA")]
        public string hexColorWithAlpha;

        [Margin(all: 5)]
        [BorderWidth(all: 2), BorderColor("0,255,0")]
        public string rgbText;

        [Margin(all: 5)]
        [BorderWidth(all: 2), BorderColor("0,255,0,128")]
        public string rgbaText;

        [Margin(all: 5)]
        [BorderWidth(all: 2), BorderColor(vertical: "#FF0000", horizontal: "#0000FF")]
        public string axis;

        [Margin(all: 5)]
        [BorderWidth(all: 2), BorderColor(bottom: "#FFFF00", left: "#FF0000")]
        public string specificDirection;
    }
}
