﻿using Naukri.InspectorMaid.Editor.Extensions;
using System;

namespace Naukri.InspectorMaid.Editor.Services
{
    public partial interface IEditorEventService
    {
        public event Action OnSceneGUI;

        public event Action OnDestroy;

        public event Action OnUpdate;

        public void InvokeUpdate();

        public void InvokeSceneGUI();

        public void InvokeDestroy();
    }

    partial interface IEditorEventService
    {
        public static IEditorEventService Of(IBuildContext context)
        {
            return context.GetService<IEditorEventService>();
        }
    }
}