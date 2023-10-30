using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples
{
    public class PropertyAndMethodSample : MonoBehaviour
    {
        [Divider("Field")]
        public int field;

        [Divider("Property")]
        [HelpBox("You can show property by adding any WidgetAttribute to them.", messageType: HelpBoxMessageType.Info), Style(marginBottom: "5")]
        public int Property { get => field; set => field = value; }

        [Target]
        public int ReadonlySample => field;

        [Divider("Method")]
        [HelpBox("You can also show method by adding any WidgetAttribute to them.", messageType: HelpBoxMessageType.Info), Style(marginBottom: "5")]
        public void Method()
        {
            Debug.Log("Hello world!");
        }

        [Target]
        public void MethodWithArgs(string target, string message)
        {
            Debug.Log($"Hello {target}, {message}!");
        }

        [Target]
        public void MethodWithDefaultArgs(string target = "my friend", string message = "have a nice day")
        {
            Debug.Log($"Hello {target}, {message}!");
        }
    }
}
