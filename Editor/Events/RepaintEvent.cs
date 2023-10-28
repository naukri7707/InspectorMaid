using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Events
{
    public class RepaintEvent : InspectorMaidEvent<RepaintEvent>
    {
        public RepaintEvent()
        {
            LocalInit();
        }

        public static RepaintEvent GetPooled(VisualElement target)
        {
            var evt = GetPooled();
            evt.target = target;

            return evt;
        }

        protected override void Init()
        {
            base.Init();
            LocalInit();
        }

        private void LocalInit()
        {
            tricklesDown = false;
            bubbles = false;
        }
    }
}
