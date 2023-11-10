using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class ButtonSample : AttributeSampleBehaviour
    {
        [HelpBox("[Button] can invoke binded method on user click.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [Button("Click", binding: nameof(MyMethod))]
        public int ButtonBeforeTarget = 0;

        [CardScope(color: kSectionBGColor)]
        // Sample 2
        // The 'Target' attribute is used to mark where the member's field should be drawn.
        [Target]
        [Button("Click", binding: nameof(MyMethod))]
        public int ButtonAfterTarget = 0;

        [CardScope(color: kSectionBGColor)]
        // Sample 3
        // In order to place the Button and Target on the same line,
        // we can use row to wrap them inside.
        [RowScope]
        [Button("Click", binding: nameof(MyMethod))]
        [Target, Style(flexGrow: "1")] // In this case we need to set flexGrow to 1 to let Target fill the remaining space.
        public int ButtonBeforeTargetInRow = 0;

        [CardScope(color: kSectionBGColor)]
        // Sample 4
        [RowScope]
        [Target, Style(flexGrow: "1")]
        [Button("Click", binding: nameof(MyMethod))]
        public int ButtonAfterTargetInRow = 0;

        [HelpBox("[Button] can also invoke method with parameters.", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 5
        // The 'args' parameter is of type object[], so when passing arguments, you typically declare an object[] when there are multiple arguments.
        // However, when you have only one argument, because of 'params' keyword, you can pass that argument without declaring an object[].
        [Button("One Parameter", binding: nameof(MyMethodWithOnlyOneParameter), args: "my message")]
        [Button("Multi Parameters", binding: nameof(MyMethodWithParameters), args: new object[] { "hello", "world" })]
        public int ButtonWithArgs = 0;

        public void MyMethod()
        {
            Debug.Log("Hello world!");
        }

        public void MyMethodWithOnlyOneParameter(string message)
        {
            Debug.Log(message);
        }

        public void MyMethodWithParameters(string message, string anotherMessage)
        {
            Debug.Log($"{message}, {anotherMessage}");
        }
    }
}
