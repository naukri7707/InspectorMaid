using UnityEngine;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class LabelSample : MonoBehaviour
    {
        public string bindingLabelText = "Label With Binding";

        [Label("newLabel")]
        public int myField;

        [Label("newLabelWithNicifyName", useNicifyName: true)]
        public int myField2;

        [Label(binding: nameof(bindingLabelText))]
        public int myField3;
    }
}
