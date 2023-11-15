using Naukri.InspectorMaid.Editor.Extensions;
using System;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Services
{
    public partial interface ICallbackService
    {
        public event Action OnClassElementAttachToPanel;

        public event Action OnClassElementDetachFromPanel;

        public event Action OnEditorUpdate;

        public void RegisterCallback(VisualElement visualElement);
    }

    partial interface ICallbackService
    {
        public static ICallbackService Of(IBuildContext context)
        {
            return context.GetService<ICallbackService>();
        }
    }
}
