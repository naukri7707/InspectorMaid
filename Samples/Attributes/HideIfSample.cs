using UnityEngine;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class HideIfSample : MonoBehaviour
    {
        public bool hide;

        [HideIfScope(binding: nameof(hide))]
        public int myField;
    }
}
