using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public sealed class DecoratorElement : VisualElement
    {
        public DecoratorElement(string name)
        {
            base.name = name;
        }

        public event EditorEvent OnDestroy = decorator => { };

        public event EditorEvent OnSceneGUI = decorator => { };

        public event EditorEvent OnStart = decorator => { };

        internal static void InvokeOnDestroy(DecoratorElement decorator) => decorator.OnDestroy.Invoke(decorator);

        internal static void InvokeOnSceneGUI(DecoratorElement decorator) => decorator.OnSceneGUI.Invoke(decorator);

        internal static void InvokeOnStart(DecoratorElement decorator) => decorator.OnStart.Invoke(decorator);

        public delegate void EditorEvent(DecoratorElement decorator);
    }
}
