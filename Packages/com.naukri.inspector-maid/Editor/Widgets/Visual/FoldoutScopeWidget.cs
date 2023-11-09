using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class FoldoutScopeWidget : VisualWidgetOf<FoldoutScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var foldout = new Foldout
            {
                text = attribute.text,
                value = attribute.expend
            };

            new ComposerOf(foldout)
            {
                children = context.BuildChildren(),
            };

            return foldout;
        }
    }
}
