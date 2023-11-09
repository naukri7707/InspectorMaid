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
    public class MethodsWidget : VisualWidgetOf<MethodsAttribute>, IContextAttachedReceiver
    {
        public override VisualElement Build(IBuildContext context)
        {
            var methods = new ComposerOf(new Methods())
            {
                children = context.BuildChildren()
            };

            return methods;
        }

        public void OnContextAttached(Context context)
        {
            var templateService = IMemberWidgetTemplates.Of(context);

            var infos = (attribute as IDeclaredTypeProvider)
                .DeclaredType
                .GetMethods(InspectorMaidUtility.kAllDeclaredAccessFlags)
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

        private class Methods : VisualElement { }
    }
}
