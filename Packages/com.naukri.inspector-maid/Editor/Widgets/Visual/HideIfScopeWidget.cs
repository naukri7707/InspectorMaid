using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class HideIfScopeWidget : ScopeWidgetOf<HideIfScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var hide = context.GetBindingValue<bool>();

            var container = new VisualElement();

            BuildChildren(context, (ctx, e) =>
            {
                container.Add(e);
            });

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
