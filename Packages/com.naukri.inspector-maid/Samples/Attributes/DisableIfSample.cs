using UnityEngine;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class DisableIfSample : MonoBehaviour
    {
        public bool disable;

        [DisableIfScope(binding: nameof(disable))]
        public int myField;
    }
}
