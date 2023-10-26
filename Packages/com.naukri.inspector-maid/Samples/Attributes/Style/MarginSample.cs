using Naukri.InspectorMaid.Style;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples
{
    public class MarginSample : MonoBehaviour
    {
        [Container, BackgroundColor("#FF0000"), Margin(all: 10, LengthUnit.Pixel)]
        [BackgroundColor("#0000FF")]
        public string all;

        [Container, BackgroundColor("#FF0000"), Margin(vertical: 20, horizontal: 10)]
        [BackgroundColor("#0000FF")]
        public string axis;

        [Container, BackgroundColor("#FF0000"), Margin(bottom: 5)]
        [BackgroundColor("#0000FF")]
        public string specific;

        [Container, BackgroundColor("#FF0000"), Margin(left: 10, leftUnit: LengthUnit.Percent)]
        [BackgroundColor("#0000FF")]
        public string withUnit;
    }
}
