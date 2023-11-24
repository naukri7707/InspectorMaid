using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.UIElements;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class GroupScopeWidget : VisualWidgetOf<GroupScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var group = new Group(attribute.text).Compose(ve =>
            {
                ve.children = context.BuildChildren();
            });

            group.Expend = attribute.expend;

            return group;
        }
    }
}
