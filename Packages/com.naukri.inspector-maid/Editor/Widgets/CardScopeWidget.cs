using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class CardScopeWidget : WidgetOf<CardScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var styleColor = model.color;

            var card = styleColor.HasValue switch
            {
                true => new Card(styleColor.Value.value),
                false => new Card(),
            };

            card.AddChildrenOf(context);

            return card;
        }
    }
}
