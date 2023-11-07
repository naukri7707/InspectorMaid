using Naukri.InspectorMaid.Editor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class CardScopeWidget : ScopeWidgetOf<CardScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var styleColor = attribute.color;

            var card = styleColor.HasValue switch
            {
                true => new Card(styleColor.Value.value),
                false => new Card(),
            };

            BuildChildren(context, (ctx, e) =>
            {
                card.Add(e);
            });

            return card;
        }
    }
}
