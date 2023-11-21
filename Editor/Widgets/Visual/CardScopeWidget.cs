using Naukri.InspectorMaid.Editor.UIElements;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class CardScopeWidget : VisualWidgetOf<CardScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var styleColor = attribute.color;

            var card = styleColor.HasValue switch
            {
                true => new Card(styleColor.Value.value),
                false => new Card(),
            };

            card.Compose(c =>
            {
                c.children = BuildChildren(context);
            });

            return card;
        }
    }
}
