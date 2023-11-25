using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public class ReadOnlyWidget : StylerWidgetOf<ReadOnlyAttribute>
    {
        public override string ClassName => "readonly-styler";

        public override void OnStyling(IBuildContext context, VisualElement element)
        {
            element.SetEnabled(false);
        }
    }
}
