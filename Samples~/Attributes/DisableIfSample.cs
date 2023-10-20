using UnityEngine;

namespace Naukri.InspectorMaid.Samples
{
    public class DisableIfSample : MonoBehaviour
    {
        public bool disable;

        [DisableIf(binding = nameof(disable))]
        public int myField;
    }
}
