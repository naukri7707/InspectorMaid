using Naukri.InspectorMaid.Editor.UIElements;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class RowScopeWidget : VisualWidgetOf<RowScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var row = new Row().Compose(c =>
            {
                c.children = context.BuildChildren();
            });

            return row;
        }
    }
}
