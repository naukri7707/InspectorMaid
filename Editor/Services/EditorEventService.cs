using System;

namespace Naukri.InspectorMaid.Editor.Services
{
    internal sealed class EditorEventService
    {
        public Action OnSceneGUI = () => { };

        public Action OnDestroy = () => { };

        public static EditorEventService Of(IWidget widget)
        {
            return widget.GetService<EditorEventService>();
        }
    }
}
