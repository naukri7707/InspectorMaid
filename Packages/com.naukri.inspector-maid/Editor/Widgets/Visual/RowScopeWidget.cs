using Naukri.InspectorMaid.Editor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class RowScopeWidget : ScopeWidgetOf<RowScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var row = new Row();

            BuildChildren(context, (ctx, e) =>
            {
                row.Add(e);
            });

            return row;
        }
    }
}
