using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Events
{
    public partial class RepaintEvent : WidgetEvent<RepaintEvent>
    {
        public RepaintEvent()
        {
            LocalInit();
        }

        protected override void Init()
        {
            base.Init();
            LocalInit();
        }

        private void LocalInit()
        {
            tricklesDown = false;
            bubbles = true;
        }
    }

    partial class RepaintEvent
    {
        public static RepaintEvent GetPooled(VisualElement target)
        {
            var evt = GetPooled();
            evt.target = target;

            return evt;
        }
    }
}
