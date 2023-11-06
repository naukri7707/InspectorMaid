using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.Services;
using UnityEditor;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class LabelWidget : WidgetOf<LabelAttribute>, ITargetCreatedReceiver
    {
        public override VisualElement Build(IBuildContext context)
        {
            return null;
        }

        public void OnTargetCreated(IBuildContext context, VisualElement targetElement)
        {
            targetElement.RegisterCallback<AttachToPanelEvent>(evt =>
            {
                // The label for PropertyField is build while PropertyField attached to the panel.
                // If we attempt to retrieve the labelElement before the AttachToPanelEvent, we will receive a null value.
                // Therefore, it is advisable to obtain the label during the AttachToPanelEvent.
                var labelElement = targetElement.Q<Label>();

                if (labelElement != null)
                {
                    var labelText = model.label;

                    labelElement.text = ActualLabel(labelText);

                    if (context.IsBinding())
                    {
                        context.ListenBindingValue<string>(message =>
                        {
                            labelElement.text = ActualLabel(message);
                        });
                    }
                }
            });
        }

        private string ActualLabel(string labelText)
        {
            return model.useNicifyName
                ? ObjectNames.NicifyVariableName(labelText)
                : labelText;
        }
    }
}
