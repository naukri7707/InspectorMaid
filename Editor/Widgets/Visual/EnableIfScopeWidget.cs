using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class EnableIfScopeWidget : ScopeWidgetOf<EnableIfScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var enable = context.GetBindingValue<bool>();

            var container = new VisualElement();

            BuildChildren(context, (ctx, e) =>
            {
                container.Add(e);
            });

            container.SetEnabled(enable);

            context.ListenBindingValue<bool>(e =>
            {
                container.SetEnabled(e);
            });

            return container;
        }
    }
}
