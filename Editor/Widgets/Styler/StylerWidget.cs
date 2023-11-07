using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public abstract class StylerWidget : NoneChildWidget, IParentBuildedReceiver
    {
        public abstract void OnStyling(IStyle style);

        public virtual void OnParentBuilded(IBuildContext context)
        {
            context.VisitAncestorContexts(ctx =>
            {
                if (ctx is VisualContext visualContext && visualContext.renderedElement != null)
                {
                    OnStyling(visualContext.renderedElement.style);
                    return true;
                }
                return false;
            });
        }
    }
}
