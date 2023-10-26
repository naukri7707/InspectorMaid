using Naukri.InspectorMaid.Style;
using UnityEngine;

namespace Naukri.InspectorMaid.Samples
{
    public class BorderWidthSample : MonoBehaviour
    {
        [Margin(all: 5)]
        [BorderWidth(2), BorderColor("#FF0000")]
        public string all;

        [Margin(all: 5)]
        [BorderWidth(vertical: 3, horizontal: 1), BorderColor("#FF0000")]
        public string axis;

        [Margin(all: 5)]
        [BorderWidth(left: 4), BorderColor("#FF0000")]
        public string specific;

        [Margin(all: 5)]
        [BorderWidth("2"), BorderColor("#00FF00")]
        public string textAll;

        [Margin(all: 5)]
        [BorderWidth("3,1"), BorderColor("#00FF00")]
        public string textAxis;

        [Margin(all: 5)]
        [BorderWidth("0,0,0,4"), BorderColor("#00FF00")]
        public string textSpecific;
    }
}
