using Naukri.InspectorMaid.Style;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples
{
    public class MarginSample : MonoBehaviour
    {
        [Margin(all: 10), BackgroundColor("#FF0000"), Container]
        [BackgroundColor("#0000FF")]
        public string all;

        [Margin(vertical: 20, horizontal: 10), BackgroundColor("#FF0000"), Container]
        [BackgroundColor("#0000FF")]
        public string axis;

        [Margin(bottom: 5), BackgroundColor("#FF0000"), Container]
        [BackgroundColor("#0000FF")]
        public string specific;

        [Margin(left: 10, leftUnit: LengthUnit.Percent), BackgroundColor("#FF0000"), Container]
        [BackgroundColor("#0000FF")]
        public string withUnit;
    }
}
