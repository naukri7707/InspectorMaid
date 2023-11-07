using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class DisableIfScopeWidget : VisualWidgetOf<DisableIfScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var disable = context.GetBindingValue<bool>();
            var container = new VisualElement()
                .AddChildrenOf(context);

            container.SetEnabled(!disable);

            context.ListenBindingValue<bool>(d =>
            {
                container.SetEnabled(!d);
            });

            return container;
        }
    }
}
