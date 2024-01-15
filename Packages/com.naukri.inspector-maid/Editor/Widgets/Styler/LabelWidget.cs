using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using PlasticGui.Gluon.WorkspaceWindow.Views.IncomingChanges;
using UnityEditor;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public class LabelWidget : StylerWidgetOf<LabelAttribute>
    {
        public override string ClassName => "label-styler";

        public override void OnStyling(IBuildContext context, VisualElement element)
        {
            // The label for PropertyField is build while PropertyField attached to the panel.
            // If we attempt to retrieve the labelElement before the AttachToPanelEvent, we will receive a null value.
            // Therefore, it is advisable to obtain the label during the AttachToPanelEvent.
            element.RegisterCallback<AttachToPanelEvent>(evt =>
            {
                // Special handling for replaceText
                if (attribute.replaceText != null)
                {
                    var labelElements = element.Query<Label>().Where(it => it.text.Contains(attribute.replaceText)).ToList();

                    if (labelElements != null)
                    {
                        foreach (var labelElement in labelElements)
                        {
                            var labelText = labelElement.text.Replace(attribute.replaceText, attribute.label);
                            labelElement.text = ActualLabel(labelText);
                            if (attribute.minWidth != float.NaN)
                            {
                                labelElement.style.minWidth = attribute.minWidth;
                            }
                        }

                        if (attribute.IsBinding())
                        {
                            context.ListenBindingValue<string>(message =>
                            {
                                foreach (var labelElement in labelElements)
                                {
                                    var labelText = labelElement.text.Replace(attribute.replaceText, message);
                                    labelElement.text = ActualLabel(labelText);
                                    if (attribute.minWidth != float.NaN)
                                    {
                                        labelElement.style.minWidth = attribute.minWidth;
                                    }
                                }
                            });
                        }
                    }
                }
                // Normal handling
                else
                {
                    var labelElement = element.Q<Label>();

                    if (labelElement != null)
                    {
                        var labelText = attribute.label;

                        labelElement.text = ActualLabel(labelText);

                        if (attribute.minWidth != float.NaN)
                        {
                            labelElement.style.minWidth = attribute.minWidth;
                        }

                        if (attribute.IsBinding())
                        {
                            context.ListenBindingValue<string>(message =>
                            {
                                labelElement.text = ActualLabel(message);

                                if (attribute.minWidth != float.NaN)
                                {
                                    labelElement.style.minWidth = attribute.minWidth;
                                }
                            });
                        }
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
