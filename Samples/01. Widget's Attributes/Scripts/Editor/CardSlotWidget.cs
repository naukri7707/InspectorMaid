using Naukri.InspectorMaid.Converters;
using Naukri.InspectorMaid.Editor;
using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Editor
{
    public class CardSlotWidget : VisualWidgetOf<CardSlotAttribute>, IContextAttachedReceiver
    {
        private static StyleColor? _defaultBGColor;

        public static StyleColor? DefaultBGColor
        {
            get
            {
                if (_defaultBGColor == null)
                {
                    _defaultBGColor = StyleStringConverter.ToStyleColor(CardSlotAttribute.kDefaultBGColor);
                }
                return _defaultBGColor;
            }
        }

        public override VisualElement Build(IBuildContext context)
        {
            var card = new Card();
            card.style.backgroundColor = DefaultBGColor.Value;
            BuildChildren(context, (ctx, e) =>
            {
                card.Add(e);
            });

            return card;
        }

        public void OnContextAttached(Context context)
        {
            var slotAttribute = new SlotAttribute(attribute.templateName);

            var slotWidget = WidgetBuilder.Create(slotAttribute);
            var slotContext = slotWidget.CreateContext();
            context.Attach(slotContext);
        }
    }
}
