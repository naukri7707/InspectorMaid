﻿using System;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public class DecoratorElement : VisualElement
    {
        public DecoratorElement(string name)
        {
            base.name = name;
        }

        internal bool IsStarted { get; set; }

        public event Action OnDestroy = () => { };

        public event Action OnSceneGUI = () => { };

        public event Action OnStart = () => { };

        internal static void InvokeOnDestroy(DecoratorElement decorator) => decorator.OnDestroy.Invoke();

        internal static void InvokeOnSceneGUI(DecoratorElement decorator) => decorator.OnSceneGUI.Invoke();

        internal static void InvokeOnStart(DecoratorElement decorator) => decorator.OnStart.Invoke();
    }
}