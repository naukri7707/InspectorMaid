using Naukri.InspectorMaid.Editor.Events;
using System;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public sealed class Decorator : VisualElement
    {
        public Decorator() : this("Decorator") { }

        public Decorator(string name)
        {
            base.name = name;
        }

        internal bool IsStarted { get; set; }

        public event Action OnDestroy = () => { };

        public event Action OnSceneGUI = () => { };

        public event Action OnStart = () => { };

        public void Repaint()
        {
            using var evt = RepaintEvent.GetPooled();
            evt.target = this;
            SendEvent(evt);
        }

        internal static void InvokeOnDestroy(Decorator decorator) => decorator.OnDestroy.Invoke();

        internal static void InvokeOnSceneGUI(Decorator decorator) => decorator.OnSceneGUI.Invoke();

        internal static void InvokeOnStart(Decorator decorator) => decorator.OnStart.Invoke();
    }
}
