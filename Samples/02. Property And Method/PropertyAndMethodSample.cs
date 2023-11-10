using Naukri.InspectorMaid.Layout;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples
{
    [Divider("Field")]
    [Fields]
    [Divider("Property")]
    [HelpBox("You can show property by adding any WidgetAttribute to them.", messageType: HelpBoxMessageType.Info), Style(marginBottom: "5")]
    [Properties]
    [Divider("Method")]
    [HelpBox("You can also show method by adding any WidgetAttribute to them.", messageType: HelpBoxMessageType.Info), Style(marginBottom: "5")]
    [Methods]
    public class PropertyAndMethodSample : MonoBehaviour
    {
        public int field;

        public int Property { get => field; set => field = value; }

        [Target]
        public int ReadonlyProperty => field;

        [Target]
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
