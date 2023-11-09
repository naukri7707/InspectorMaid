using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using Naukri.InspectorMaid.Layout;
using System.Reflection;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual.Layout
{
    public class PropertiesWidget : ItemWidgetOf<PropertiesAttribute>, IContextAttachedReceiver
    {
        public override VisualElement Build(IBuildContext context)
        {
            var container = new VisualElement()
            {
                name = "Properties"
            };

            BuildChildren(context, (ctx, e) =>
            {
                container.Add(e);
            });

            return container;
        }

        public void OnContextAttached(Context context)
        {
            var templateService = IMemberWidgetTemplates.Of(context);

            var widgets = templateService.CreateMemberWidgets(info => info.MemberType == MemberTypes.Property);

            foreach (var widget in widgets)
            {
                if (attribute.skipTemplate && widget.IsTemplate)
                {
                    continue;
                }
                var memberContext = widget.CreateContext();
                memberContext.AttachParent(context);
            }
        }
    }
}
