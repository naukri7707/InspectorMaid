using Naukri.InspectorMaid.Editor.Contexts.Core;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public abstract class VisualWidget : IWidget
    {
        public abstract VisualContext CreateContext();

        public abstract VisualElement Build(IBuildContext context);

        // We must keep BuildChildren() in [VisualWidget] instead of [ScopeWidget].
        // Because [ItemWidget] may create child context through [IContextAttachedReceiver],
        // in this case, we still need to use BuildChildren() to create child elements.
        public VisualElement[] BuildChildren(IBuildContext context, ChildBuildedCallback callback = null)
        {
            var children = new List<VisualElement>();
            context.VisitChildContexts(child =>
            {
                if (child is VisualContext visualContext)
                {
                    var childElement = visualContext.Build();

                    if (childElement != null)
                    {
                        callback?.Invoke(child, childElement);
                        children.Add(childElement);
                    }
                }
            });

            return children.ToArray();
        }

        Context IWidget.CreateContext() => CreateContext();

        public delegate void ChildBuildedCallback(Context ctx, VisualElement e);
    }
}
