using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox("[Hide] will hide lastest widget.", HelpBoxMessageType.Info)]
    [Divider("01. Hide any widget")]
    [CardSlot(nameof(hideWidget))]
    [Divider("02. Hide [Target]")]
    [HelpBox(@"Because [Hide] is a styler, so we need add [Target] before it, otherwise it will hide lastest widget: [Button].", HelpBoxMessageType.Warning)]
    [CardSlot(nameof(bad))]
    [CardSlot(nameof(good))]
    [Divider("03. Hide multiple widgets")]
    [CardSlot(nameof(hideMultipleWidgets))]
    [Divider("04. Simpify trick")]
    [HelpBox(@"If there is no widget before the styler, the styler will modify the [MemberWidget] (a simple container of all widgets in this member).
So if you don't have any other widget, and only want to hide the [Target], you can simply add [Hide] to the member.", HelpBoxMessageType.Info)]
    [Slot(nameof(hideMember))]
    public class HideSample : AttributeSampleBehaviour
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
        // Use [Hide] to hide the lastest widget: [ColumnScope], so that all widgets in this scope will be hide.
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
}
