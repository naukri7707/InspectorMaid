using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class HideIfScopeWidget : VisualWidgetOf<HideIfScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var hide = context.GetBindingValue<bool>();

            var container = new VisualElement()
                .AddChildrenOf(context);

            if (hide)
            {
                container.style.display = DisplayStyle.None;
                container.style.visibility = Visibility.Hidden;
            }
            else
            {
                container.style.display = DisplayStyle.Flex;
                container.style.visibility = Visibility.Visible;
            }

            context.ListenBindingValue<bool>(h =>
            {
                if (h)
                {
                    container.style.display = DisplayStyle.None;
                    container.style.visibility = Visibility.Hidden;
                }
                else
                {
                    container.style.display = DisplayStyle.Flex;
                    container.style.visibility = Visibility.Visible;
                }
            });

            return container;
        }
    }
}
