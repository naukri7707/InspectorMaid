using System;
using UnityEditor;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Services.Default
{
    internal sealed class CallbackService : ICallbackService
    {
        public event Action OnClassElementAttachToPanel = () => { };

        public event Action OnClassElementDetachFromPanel = () => { };

        public event Action OnEditorUpdate = () => { };

        public void RegisterCallback(VisualElement visualElement)
        {
            visualElement.RegisterCallback<AttachToPanelEvent>(callback =>
            {
                OnClassElementAttachToPanel.Invoke();
                EditorApplication.update += InvokeEditorUpdate;
            });
            visualElement.RegisterCallback<DetachFromPanelEvent>(callback =>
            {
                OnClassElementDetachFromPanel.Invoke();
                EditorApplication.update -= InvokeEditorUpdate;
            });
        }

        private void InvokeEditorUpdate()
        {
            OnEditorUpdate?.Invoke();
        }
    }
}
