using Naukri.InspectorMaid.Editor.Contexts.Core;
using UnityEngine.UIElements;
using static Naukri.InspectorMaid.Editor.Widgets.Core.ScopeWidget;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public abstract class VisualWidget : IWidget
    {
        public abstract VisualContext CreateContext();

        public abstract VisualElement Build(IBuildContext context);

        // We must keep BuildChildren() in [VisualWidget] instead of [ScopeWidget].
        // Because [ItemWidget] may create child context through [IContextAttachedReceiver],
        // in this case, we still need to use BuildChildren() to create child elements.
        public void BuildChildren(IBuildContext context, ChildBuildedCallback callback)
        {
            context.VisitChildContexts(child =>
            {
                if (child is VisualContext visualContext)
                {
                    var childElement = visualContext.Build();

                    if (childElement != null)
                    {
                        callback(child, childElement);
                    }
                }
            });
        }

        Context IWidget.CreateContext() => CreateContext();
    }
}
