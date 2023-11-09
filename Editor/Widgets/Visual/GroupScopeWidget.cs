using Naukri.InspectorMaid.Editor.UIElements;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class GroupScopeWidget : VisualWidgetOf<GroupScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var group = new Group(attribute.text)
            {
                Expend = attribute.expend
            };

            new ComposerOf(group)
            {
                children = context.BuildChildren()
            };

            return group;
        }
    }
}
