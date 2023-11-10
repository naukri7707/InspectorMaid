using System;

namespace Naukri.InspectorMaid.Editor.Services.Default
{
    internal sealed class EditorEventService : IEditorEventService
    {
        public event Action OnUpdate = () => { };

        public event Action OnSceneGUI = () => { };

        public event Action OnDestroy = () => { };

        public void InvokeUpdate() => OnUpdate.Invoke();

        public void InvokeSceneGUI() => OnSceneGUI.Invoke();

        public void InvokeDestroy() => OnDestroy.Invoke();
    }
}
