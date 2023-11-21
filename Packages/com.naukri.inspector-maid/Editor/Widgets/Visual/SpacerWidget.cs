using Naukri.InspectorMaid.Editor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class SpacerWidget : VisualWidgetOf<SpacerAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var spacer = attribute.flexGrow.HasValue switch
            {
                true => new Spacer(attribute.flexGrow.Value.value),
                false => new Spacer()
            };

            return spacer;
        }
    }
}
