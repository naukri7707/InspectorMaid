using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [HelpBox("[OnChanged] can help you listen to the target member and invokes the target method when changes occur.", HelpBoxMessageType.Info)]
    [Divider("01. OnChanged")]
    [CardSlot(nameof(myInt))]
    [Divider("02. OnChanged and modify field")]
    [HelpBox("Notice that Inspector-Maid only work in Unity's editor, so [OnChanged] won't be invoked during runtime.", HelpBoxMessageType.Warning)]
    [CardScope(color: CardSlotAttribute.kDefaultBGColor)]
    [Slot(nameof(myInt2))]
    [Slot(nameof(checkedIfMyInt2Is100))]
    [EndScope]
    public class OnChangedSample : AttributeSampleBehaviour
    {
        // Sample 1
        [OnChanged(nameof(LogChanged))]
        public int myInt;

        // Sample 2
        // If the binding method modifies the field, you should use 'setDirty = true' to record the change.
        [OnChanged(nameof(LogChanged2), setDirty = true)]
        public int myInt2;

        public bool checkedIfMyInt2Is100;

        public void LogChanged()
        {
            print($"{nameof(myInt)} changed to {myInt}");
        }

        public void LogChanged2()
        {
            checkedIfMyInt2Is100 = myInt2 == 100;
        }
    }
}
