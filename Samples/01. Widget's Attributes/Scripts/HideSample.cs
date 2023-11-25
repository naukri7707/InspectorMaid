using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public partial class HideSample : AttributeSampleBehaviour
    {
        // Sample 1
        [Button("Click me!", binding: nameof(HelloWorld)), Hide]
        public int hideWidget;

        // Sample 2
        [Button("Click me!", binding: nameof(HelloWorld))]
        [Hide]
        public int bad;

        [Button("Click me!", binding: nameof(HelloWorld))]
        [Target, Hide]
        public int good;

        // Sample 3
        // Use [Hide] to disable the lastest widget: [ColumnScope], so that all widgets in this scope will be disabled.
        [ColumnScope, Hide]
        [Button("Button 1", binding: nameof(HelloWorld))]
        [Button("Button 2", binding: nameof(HelloWorld))]
        [EndScope]
        public int hideMultipleWidgets;

        // Sample 4
        [Hide]
        public int hideMember;

        public void HelloWorld()
        {
            Debug.Log("Hello world!");
        }
    }

    [
    HelpBox("[Hide] will disable lastest widget.", HelpBoxMessageType.Info),
    // Sample 1
    GroupScope("01. Disable any widget"),
        CardSlot(nameof(hideWidget)),
    EndScope,
    // Sample 2
    GroupScope("02. Disable [Target]"),
        HelpBox(@"Because [Hide] is a styler, so we need add [Target] before it, otherwise it will disable lastest widget: [Button].", HelpBoxMessageType.Warning),
        CardSlot(nameof(bad)),
        CardSlot(nameof(good)),
    EndScope,
    // Sample 3
    GroupScope("03. Disable multiple widgets"),
        CardSlot(nameof(hideMultipleWidgets)),
    EndScope,
    // Sample 4
    GroupScope("04. Simpify trick"),
        HelpBox(@"If there is no widget before the styler, the styler will modify the [MemberWidget] (a simple container of all widgets in this member).
So if you don't have any other widget, and only want to disable [Target], you can simply add [Hide] to the member.", HelpBoxMessageType.Info),
        Slot(nameof(hideMember)),
    EndScope,
    ]
    partial class HideSample { }
}
