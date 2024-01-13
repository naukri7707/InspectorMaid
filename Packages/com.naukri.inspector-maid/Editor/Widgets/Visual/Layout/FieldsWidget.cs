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
    public class FieldsWidget : VisualWidgetOf<FieldsAttribute>, IContextAttachedReceiver
    {
        public override VisualElement Build(IBuildContext context)
        {
            var fields = new ComposerOf(new Fields())
            {
                children = context.BuildChildren(),
            };

            return fields;
        }

        public void OnContextAttached(Context context)
        {
            var templateService = IMemberWidgetTemplates.Of(context);

            var infos = (attribute as IDeclaredTypeProvider)
                .DeclaredType
                .GetFields(InspectorMaidUtility.kAllDeclaredAccessFlags)
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

        private class Fields : VisualElement { }
    }
}
