using Naukri.InspectorMaid.Editor.UIElements;
using Naukri.InspectorMaid.Layout;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class ScriptFieldWidget : VisualWidgetOf<ScriptFieldAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var classWidget = ClassWidget.Of(context);
            var serializedProperty = classWidget.GetSerializedProperty();

            var scriptField = new ScriptField(serializedProperty.serializedObject);

            return scriptField;
        }
    }
}
