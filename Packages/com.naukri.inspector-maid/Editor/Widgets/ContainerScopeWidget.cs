using Naukri.InspectorMaid.Editor.Extensions;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class ContainerScopeWidget : VisualWidgetOf<ContainerScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            return new VisualElement()
                .AddChildrenOf(context);
        }
    }
}
