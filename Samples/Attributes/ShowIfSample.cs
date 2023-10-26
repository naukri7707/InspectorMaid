using UnityEngine;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class ShowIfSample : MonoBehaviour
    {
        public bool show;

        [ShowIfScope(binding: nameof(show))]
        public int myField;
    }
}
