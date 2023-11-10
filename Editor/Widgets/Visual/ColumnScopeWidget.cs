using UnityEngine.UIElements;
using Column = Naukri.InspectorMaid.Editor.UIElements.Column;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class ColumnScopeWidget : ScopeWidgetOf<ColumnScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var column = new Column();

            BuildChildren(context, (ctx, e) =>
            {
                column.Add(e);
            });

            return column;
        }
    }
}
