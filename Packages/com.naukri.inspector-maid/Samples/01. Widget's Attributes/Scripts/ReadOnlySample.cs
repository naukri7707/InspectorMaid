using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox("[ReadOnly] will disable lastest widget.", HelpBoxMessageType.Info)]
    [Divider("01. Disable any widget")]
    [CardSlot(nameof(readonlyWidget))]
    [Divider("02. Disable [Target]")]
    [HelpBox(@"Because [ReadOnly] is a styler, so we need add [Target] before it, otherwise it will disable lastest widget: [Button].", HelpBoxMessageType.Warning)]
    [CardSlot(nameof(bad))]
    [CardSlot(nameof(good))]
    [Divider("03. Disable multiple widgets")]
    [CardSlot(nameof(readOnlyMultipleWidgets))]
    [Divider("04. Simpify trick")]
    [HelpBox(@"If there is no widget before the styler, the styler will modify the [MemberWidget] (a simple container of all widgets in this member).
So if you don't have any other widget, and only want to disable [Target], you can simply add [ReadOnly] to the member.", HelpBoxMessageType.Info)]
    [Slot(nameof(readOnlyMember))]
    public class ReadOnlySample : AttributeSampleBehaviour
    {
        // Sample 1
        [Button("Click me!", binding: nameof(HelloWorld)), ReadOnly]
        public int readonlyWidget;

        // Sample 2
        [Button("Click me!", binding: nameof(HelloWorld))]
        [ReadOnly]
        public int bad;

        [Button("Click me!", binding: nameof(HelloWorld))]
        [Target, ReadOnly]
        public int good;

        // Sample 3
        // Use [ReadOnly] to disable the lastest widget: [ColumnScope], so that all widgets in this scope will be disabled.
        [ColumnScope, ReadOnly]
        [Button("Button 1", binding: nameof(HelloWorld))]
        [Button("Button 2", binding: nameof(HelloWorld))]
        [EndScope]
        public int readOnlyMultipleWidgets;

        // Sample 4
        [ReadOnly]
        public int readOnlyMember;

        public void HelloWorld()
        {
            Debug.Log("Hello world!");
        }
    }
}
