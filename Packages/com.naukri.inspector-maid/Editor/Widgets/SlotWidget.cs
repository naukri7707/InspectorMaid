using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class SlotWidget : VisualWidgetOf<SlotAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var container = new VisualElement()
            {
                name = "Slot"
            };

            container.AddChildrenOf(context);

            return container;
        }

        internal override void OnContextAttached(VisualContext context)
        {
            var templateService = IMemberWidgetTemplates.Of(context);
            var templateWidget = templateService.Create(attribute.templateName);

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

            templateContext.AttachParent(context);
        }
    }
}
