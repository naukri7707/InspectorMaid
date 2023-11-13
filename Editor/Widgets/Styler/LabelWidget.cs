using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using UnityEditor;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public class LabelWidget : StylerWidgetOf<LabelAttribute>
    {
        public override void OnStyling(IBuildContext context, VisualElement stylingElement)
        {
            stylingElement.RegisterCallback<AttachToPanelEvent>(evt =>
            {
                // The label for PropertyField is build while PropertyField attached to the panel.
                // If we attempt to retrieve the labelElement before the AttachToPanelEvent, we will receive a null value.
                // Therefore, it is advisable to obtain the label during the AttachToPanelEvent.
                var labelElement = stylingElement.Q<Label>();

                if (labelElement != null)
                {
                    var labelText = attribute.label;

                    labelElement.text = ActualLabel(labelText);

                    if (attribute.IsBinding())
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
            return attribute.useNicifyName
                ? ObjectNames.NicifyVariableName(labelText)
                : labelText;
        }
    }
}
