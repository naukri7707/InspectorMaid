using Naukri.InspectorMaid.Editor.Extensions;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class FoldoutScopeWidget : WidgetOf<FoldoutScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            return new Foldout
            {
                text = model.text,
                value = model.expend
            }.AddChildrenOf(context);
        }
    }
}
