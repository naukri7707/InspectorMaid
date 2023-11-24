using System;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public interface IBuildContext
    {
        public Widget Widget { get; }

        public T GetAncestorWidget<T>() where T : Widget;

        public Context GetContextOfAncestorWidget<T>() where T : Widget;

        public void VisitAncestorContexts(Predicate<Context> visitor);

        public void VisitChildContexts(Action<Context> visitor);

        public VisualElement[] BuildChildren(ChildBuiltCallback callback = null);

        public delegate void ChildBuiltCallback(Context ctx, VisualElement e);
    }
}
