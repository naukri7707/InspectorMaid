using Naukri.InspectorMaid.Editor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class DividerWidget : VisualWidgetOf<DividerAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            return new Divider(text: attribute.text);
        }
    }
}
