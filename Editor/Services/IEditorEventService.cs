using System;

namespace Naukri.InspectorMaid.Editor.Services
{
    public partial interface IEditorEventService
    {
        public event Action OnSceneGUI;

        public event Action OnDestroy;

        public event Action OnUpdate;
    }

    partial interface IEditorEventService
    {
        public static IEditorEventService Of(IBuildContext context)
        {
            return context.GetService<IEditorEventService>();
        }
    }
}
