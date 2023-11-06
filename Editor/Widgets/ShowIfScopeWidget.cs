using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class ShowIfScopeWidget : WidgetOf<ShowIfScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var show = context.GetBindingValue<bool>();

            var container = new VisualElement()
                .AddChildrenOf(context);

            if (show)
            {
                container.style.display = DisplayStyle.Flex;
                container.style.visibility = Visibility.Visible;
            }
            else
            {
                container.style.display = DisplayStyle.None;
                container.style.visibility = Visibility.Hidden;
            }

            context.ListenBindingValue<bool>(s =>
            {
                if (s)
                {
                    container.style.display = DisplayStyle.Flex;
                    container.style.visibility = Visibility.Visible;
                }
                else
                {
                    container.style.display = DisplayStyle.None;
                    container.style.visibility = Visibility.Hidden;
                }
            });

            return container;
        }
    }
}
