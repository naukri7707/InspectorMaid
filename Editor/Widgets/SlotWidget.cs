using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class SlotWidget : WidgetOf<SlotAttribute>
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

        public override Element CreateElementTree(Element parent)
        {
            var element = base.CreateElementTree(parent);
            var templateService = IMemberWidgetTemplates.Of(parent);
            var widget = templateService.Create(model.templateName);

            // Prevent endless recursion
            element.VisitAncestorElements(ance =>
            {
                if (ance.Widget is MemberWidget anceWidget)
                {
                    if (anceWidget.info == widget.info)
                    {
                        throw new System.Exception($"Endless slot recursion detected at {nameof(MemberWidget)} '{widget.info.Name}'.");
                    }
                }
                return false;
            });

            widget.CreateElementTree(element);

            return element;
        }
    }
}
