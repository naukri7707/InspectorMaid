using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class ButtonSample : MonoBehaviour
    {
        [Button("Click me!", binding: nameof(MyMethod))]
        public int myField = 0;

        [Button("Use FlexDirection to change position!", binding: nameof(MyMethod))]
        public int myField2 = 0;

        public void MyMethod()
        {
            Debug.Log("Hello world!");
        }
    }
}
