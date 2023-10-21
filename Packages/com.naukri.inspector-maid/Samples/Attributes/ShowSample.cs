using UnityEngine;

namespace Naukri.InspectorMaid.Samples
{
    public class ShowSample : MonoBehaviour
    {
        private int myField = 0;

        [Show]
        public int MyField { get => myField; set => myField = value; }
    }
}
