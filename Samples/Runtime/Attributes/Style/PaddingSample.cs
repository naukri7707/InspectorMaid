using Naukri.InspectorMaid.Style;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples
{
    public class PaddingSample : MonoBehaviour
    {
        [Padding(all: 10), BackgroundColor("#FF0000"), Container]
        [BackgroundColor("#0000FF")]
        public string all;

        [Padding(vertical: 20, horizontal: 10), BackgroundColor("#FF0000"), Container]
        [BackgroundColor("#0000FF")]
        public string axis;

        [Padding(bottom: 5), BackgroundColor("#FF0000"), Container]
        [BackgroundColor("#0000FF")]
        public string specific;

        [Padding(left: 10, leftUnit: LengthUnit.Percent), BackgroundColor("#FF0000"), Container]
        [BackgroundColor("#0000FF")]
        public string withUnit;
    }
}
