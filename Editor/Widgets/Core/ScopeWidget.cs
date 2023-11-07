using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Contexts.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public abstract class ScopeWidget : VisualWidget
    {
        public override VisualContext CreateContext() => new MultiChildVisualContext(this);

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

        public delegate void ChildBuildedCallback(Context ctx, VisualElement e);
    }
}
