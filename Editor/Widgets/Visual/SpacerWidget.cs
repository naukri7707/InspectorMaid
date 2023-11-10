using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class SpacerWidget : ItemWidgetOf<SpacerAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var spacer = new VisualElement();

            spacer.style.flexGrow = attribute.flexGrow ?? spacer.style.flexGrow;

            return spacer;
        }
    }
}
