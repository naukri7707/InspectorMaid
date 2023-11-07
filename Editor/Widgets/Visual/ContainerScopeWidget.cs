using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class ContainerScopeWidget : ScopeWidgetOf<ContainerScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var container = new VisualElement();

            BuildChildren(context, (ctx, e) =>
            {
                container.Add(e);
            });

            return container;
        }
    }
}
