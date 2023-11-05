using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class DisableIfScopeWidget : ScopeWidgetOf<DisableIfScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var disable = context.GetBindingValue<bool>();
            var container = new VisualElement();

            BuildChildren(context, (ctx, e) =>
            {
                container.Add(e);
            });

            container.SetEnabled(!disable);

            context.ListenBindingValue<bool>(d =>
            {
                container.SetEnabled(!d);
            });

            return container;
        }
    }
}
