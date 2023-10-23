using UnityEngine;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class ShowIfSample : MonoBehaviour
    {
        public bool show;

        [ShowIf(binding: nameof(show))]
        public int myField;
    }
}
