using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class EnableIfScopeWidget : WidgetOf<EnableIfScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var enable = context.GetBindingValue<bool>();

            var container = new VisualElement()
                .AddChildrenOf(context);

            container.SetEnabled(enable);

            context.ListenBindingValue<bool>(e =>
            {
                container.SetEnabled(e);
            });

            return container;
        }
    }
}
