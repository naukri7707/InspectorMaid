using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class SlotWidget : VisualWidgetOf<SlotAttribute>, IContextAttachedReceiver
    {
        public override VisualElement Build(IBuildContext context)
        {
            var container = new Slot().Compose(c =>
            {
                c.name = $"slot:{attribute.templateName}";
                c.children = BuildChildren(context);
            });

            return container;
        }

        public void OnContextAttached(Context context)
        {
            var templateService = IMemberWidgetTemplates.Of(context);
            var templateWidget = templateService.CreateMemberWidget(attribute.templateName);

            // Prevent endless recursion
            context.VisitAncestorContexts(ance =>
            {
                if (ance.Widget is MemberWidget anceWidget)
                {
                    if (anceWidget.info == templateWidget.info)
                    {
                        throw new System.Exception($"Endless slot recursion detected at {nameof(MemberWidget)} '{templateWidget.info.Name}'.");
                    }
                }
                return false;
            });

            var templateContext = templateWidget.CreateContext();

            context.Attach(templateContext);
        }

        private class Slot : VisualElement { }
    }
}
