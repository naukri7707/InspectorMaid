using Naukri.InspectorMaid.Style;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples
{
    public class OffsetSample : MonoBehaviour
    {
        [Offset(all: 10)]
        public string all;

        [Offset(vertical: 20, horizontal: -10)]
        public string axis;

        [Offset(top: -10)]
        public string specific;

        [Offset(left: 10, leftUnit: LengthUnit.Percent)]
        public string withUnit;
    }
}
