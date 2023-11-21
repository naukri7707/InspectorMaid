using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using Naukri.InspectorMaid.Layout;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual.Layout
{
    public class MembersWidget : VisualWidgetOf<MembersAttribute>, IContextAttachedReceiver
    {
        public override VisualElement Build(IBuildContext context)
        {
            var container = new Members();

            BuildChildren(context, (ctx, e) =>
            {
                container.Add(e);
            });

            return container;
        }

        public void OnContextAttached(Context context)
        {
            var templateService = IMemberWidgetTemplates.Of(context);

            var widgets = templateService.CreateMemberWidgets();

            foreach (var widget in widgets)
            {
                if (attribute.skipTemplate && widget.IsTemplate)
                {
                    continue;
                }
                var memberContext = widget.CreateContext();
                context.Attach(memberContext);
            }
        }

        private class Members : VisualElement { }
    }
}
