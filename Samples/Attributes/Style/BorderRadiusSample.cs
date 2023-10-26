using Naukri.InspectorMaid.Style;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples
{
    public class BorderRadiusSample : MonoBehaviour
    {
        [Margin(all: 5)]
        [BorderWidth(2), BorderColor("#FF0000"), BorderRadius(all: 10)]
        public string all;

        [Margin(all: 5)]
        [BorderWidth(all: 2), BorderColor("#FF0000"), BorderRadius(top: 20, bottom: 0)]
        public string vertical;

        [Margin(all: 5)]
        [BorderWidth(all: 2), BorderColor("#FF0000"), BorderRadius(topLeft: 20, bottomRight: 10)]
        public string specific;

        [Margin(all: 5)]
        [BorderWidth(all: 2), BorderColor("#00FF00"), BorderRadius("10")]
        public string textAll;

        [Margin(all: 5)]
        [BorderWidth(all: 2), BorderColor("#00FF00"), BorderRadius("20,0")]
        public string textVertical;

        [Margin(all: 5)]
        [BorderWidth(all: 2), BorderColor("#00FF00"), BorderRadius("20,0,0,10")]
        public string textSpecific;

        [Margin(all: 5)]
        [BorderWidth(all: 2), BorderColor("#0000FF"), BorderRadius(topLeft: 100, topLeftUnit: LengthUnit.Percent, bottomLeft: 10, bottomLeftUnit: LengthUnit.Pixel)]
        public string withUnit;

        [Margin(all: 5)]
        [BorderWidth(all: 2), BorderColor("#0000FF"), BorderRadius("100%,0px,10px,0px")]
        public string textWithUnit;
    }
}
