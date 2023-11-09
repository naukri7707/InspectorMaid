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
            var slot = new ComposerOf(new Slot())
            {
                name = $"slot:{attribute.templateNames}",
                children = context.BuildChildren(),
            };

            return slot;
        }

        public void OnContextAttached(Context context)
        {
            var templateService = IMemberWidgetTemplates.Of(context);

            foreach (var templateName in attribute.templateNames)
            {
                var templateWidget = templateService.CreateMemberWidget(templateName);

                // Prevent endless recursion
                context.VisitAncestorContexts(ancestor =>
                {
                    if (ancestor.Widget is MemberWidget ancestorWidget)
                    {
                        if (ancestorWidget.info == templateWidget.info)
                        {
                            throw new System.Exception($"Endless slot recursion detected at {nameof(MemberWidget)} '{templateWidget.info.Name}'.");
                        }
                    }
                    return false;
                });

                var templateContext = templateWidget.CreateContext();

                context.Attach(templateContext);
            }
        }

        private class Slot : VisualElement { }
    }
}
