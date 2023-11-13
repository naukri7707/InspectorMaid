using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class FoldoutScopeWidget : ScopeWidgetOf<FoldoutScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var container = new Foldout
            {
                text = attribute.text,
                value = attribute.expend
            }.Compose(c =>
            {
                c.children = BuildChildren(context);
            });

            return container;
        }
    }
}
