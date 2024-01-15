using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using Naukri.InspectorMaid.Layout;
using System.Linq;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual.Layout
{
    public class MembersWidget : VisualWidgetOf<MembersAttribute>, IContextAttachedReceiver
    {
        public override VisualElement Build(IBuildContext context)
        {
            var members = new ComposerOf(new Members())
            {
                children = context.BuildChildren(),
            };

            return members;
        }

        public void OnContextAttached(Context context)
        {
            var templateService = IMemberWidgetTemplates.Of(context);

            var infos = (attribute as IDeclaredTypeProvider)
                .DeclaredType
                .GetMembers(InspectorMaidUtility.kAllDeclaredAccessFlags)
                .ToHashSet();
            var widgets = templateService.CreateMemberWidgets(it => infos.Contains(it));

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
