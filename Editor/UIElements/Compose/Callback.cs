using System;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements.Compose
{
    public readonly partial struct Callback
    {
        private Callback(Action<VisualElement> register)
        {
            this.register = register;
        }

        private readonly Action<VisualElement> register;

        internal readonly void RegisterTo(VisualElement element)
        {
            register(element);
        }
    }

    partial struct Callback
    {
        public static Callback BubbleUp<TEventType>(EventCallback<TEventType> callback) where TEventType : EventBase<TEventType>, new()
        {
            return Create(callback, UnityEngine.UIElements.TrickleDown.NoTrickleDown);
        }

        public static Callback TrickleDown<TEventType>(EventCallback<TEventType> callback) where TEventType : EventBase<TEventType>, new()
        {
            return Create(callback, UnityEngine.UIElements.TrickleDown.TrickleDown);
        }

        private static Callback Create<TEventType>(EventCallback<TEventType> callback, TrickleDown trickleDown = UnityEngine.UIElements.TrickleDown.NoTrickleDown) where TEventType : EventBase<TEventType>, new()
        {
            void register(VisualElement ve) => ve.RegisterCallback(callback, trickleDown);

            var res = new Callback(register);

            return res;
        }
    }
}
