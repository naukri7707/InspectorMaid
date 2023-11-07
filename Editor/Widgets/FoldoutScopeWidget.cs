using Naukri.InspectorMaid.Editor.Extensions;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class FoldoutScopeWidget : VisualWidgetOf<FoldoutScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            return new Foldout
            {
                text = attribute.text,
                value = attribute.expend
            }.AddChildrenOf(context);
        }
    }
}
