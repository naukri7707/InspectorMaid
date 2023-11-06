using Naukri.InspectorMaid.Editor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class DividerWidget : WidgetOf<DividerAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            return new Divider(
                text: model.text
                );
        }
    }
}
