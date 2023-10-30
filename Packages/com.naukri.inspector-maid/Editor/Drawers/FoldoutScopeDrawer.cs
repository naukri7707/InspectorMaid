using System.Linq;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class FoldoutScopeDrawer : WidgetDrawerOf<FoldoutScopeAttribute>
    {
        public override void OnStart(IWidget widget)
        {
            var foldout = new Foldout
            {
                text = attribute.text,
                value = attribute.expend
            };

            // We need to cache the children before we add the foldout to the widget,
            // otherwise the loop will never end.
            var children = widget.Children().ToList();
            foreach (var child in children)
            {
                foldout.Add(child);
            }

            widget.Add(foldout);
        }
    }
}
