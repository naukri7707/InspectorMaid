using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class VisualElementExtension
    {
        public static VisualElement AddChildrenOf(this VisualElement visualElement, IBuildContext context)
        {
            context.VisitChildVisualContexts(child =>
            {
                visualElement.Add(child.Build());
            });

            return visualElement;
        }
    }
}
