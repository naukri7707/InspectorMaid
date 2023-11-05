using System;

namespace Naukri.InspectorMaid.Editor.Services.Default
{
    internal sealed class EditorEventService : IEditorEventService
    {
        public event Action OnUpdate = () => { };

        public event Action OnSceneGUI = () => { };

        public event Action OnDestroy = () => { };

        internal void InvokeUpdate() => OnUpdate.Invoke();

        internal void InvokeSceneGUI() => OnSceneGUI.Invoke();

        internal void InvokeDestroy() => OnDestroy.Invoke();
    }
}
