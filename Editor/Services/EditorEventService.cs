using System;

namespace Naukri.InspectorMaid.Editor.Services
{
    internal sealed partial class EditorEventService
    {
        public Action OnSceneGUI = () => { };

        public Action OnDestroy = () => { };
    }

    partial class EditorEventService
    {
        public static EditorEventService Of(IWidget widget)
        {
            return widget.GetService<EditorEventService>();
        }
    }
}
