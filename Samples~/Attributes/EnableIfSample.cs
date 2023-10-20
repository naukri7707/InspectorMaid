using UnityEngine;

namespace Naukri.InspectorMaid.Samples
{
    public class EnableIfSample : MonoBehaviour
    {
        public bool enable;

        [EnableIf(binding = nameof(enable))]
        public int myField;
    }
}
