using Naukri.InspectorMaid.Editor.Services;
using UnityEditor;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class ButtonWidget : ItemWidgetOf<ButtonAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var classWidget = ClassWidget.Of(context);
            var serializedTarget = classWidget.serializedTarget;

            void buttonAction()
            {
                Undo.RecordObject(serializedTarget, "Set Value");
                context.InvokeBindingAction();
                EditorUtility.SetDirty(serializedTarget);
            }

            var button = new Button(buttonAction)
            {
                text = attribute.text
            };

            return button;
        }
    }
}
