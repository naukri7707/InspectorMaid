﻿using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class ButtonSample : AttributeSampleBehaviour
    {
        // Sample 1
        [Button("Click", binding: nameof(MyMethod))]
        public int buttonBeforeTarget = 0;

        // The 'Target' attribute is used to mark where the member's field should be drawn.
        [Target]
        [Button("Click", binding: nameof(MyMethod))]
        public int buttonAfterTarget = 0;

        // In order to place the Button and Target on the same line,
        // we can use row to wrap them inside.
        [RowScope]
        [Button("Click", binding: nameof(MyMethod))]
        [Target, Style(flexGrow: "1")] // In this case we need to set flexGrow to 1 to let Target fill the remaining space.
        public int buttonBeforeTargetInRow = 0;

        [RowScope]
        [Target, Style(flexGrow: "1")]
        [Button("Click", binding: nameof(MyMethod))]
        public int buttonAfterTargetInRow = 0;

        // Sample 5
        // The 'args' parameter is of type object[], so when passing arguments, you declare an object[].
        [Button("With Parameters", binding: nameof(MyMethodWithParameters), args: new object[] { "hello", "world" })]
        public int buttonWithArgs = 0;

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

    [
    HelpBox("[Button] can invoke binded method on user click.", HelpBoxMessageType.Info),
    // Sample 1
    GroupScope("01. Button in any direction", true),
        CardSlot(nameof(buttonBeforeTarget)),
        CardSlot(nameof(buttonAfterTarget)),
        CardSlot(nameof(buttonBeforeTargetInRow)),
        CardSlot(nameof(buttonAfterTargetInRow)),
    EndScope,
    // Sample 2
    GroupScope("02. Binding with parameters", true),
        HelpBox("[Button] can also invoke method with parameters.", HelpBoxMessageType.Info),
        CardSlot(nameof(buttonWithArgs)),
    EndScope,
    ]
    partial class ButtonSample { }
}
