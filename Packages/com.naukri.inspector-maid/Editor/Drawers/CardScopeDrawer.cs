using Naukri.InspectorMaid.Editor.UIElements;
using System.Linq;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class CardScopeDrawer : WidgetDrawerOf<CardScopeAttribute>
    {
        public override void OnStart(IWidget widget)
        {
            var card = attribute.color.HasValue switch
            {
                true => new Card(attribute.color.Value.value),
                false => new Card(),
            };

            // We need to cache the children before we add the foldout to the widget,
            // otherwise the loop will never end.
            var children = widget.Children().ToList();
            foreach (var child in children)
            {
                card.hierarchy.Add(child);
            }

            widget.Add(card);
        }
    }
}
