using Naukri.InspectorMaid.Converters;
using Naukri.InspectorMaid.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid
{
    public class CardScopeAttribute : WidgetAttribute
    {
        public CardScopeAttribute(string color = null)
        {
            this.color = StringConverter.ToStyleColor(color);
        }

        public readonly StyleColor? color;
    }
}
