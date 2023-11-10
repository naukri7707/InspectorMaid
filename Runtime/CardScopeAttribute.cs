using Naukri.InspectorMaid.Converters;
using Naukri.InspectorMaid.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid
{
    public class CardScopeAttribute : ScopeAttribute
    {
        public CardScopeAttribute(string color = null)
        {
            this.color = StyleStringConverter.ToStyleColor(color);
        }

        public readonly StyleColor? color;
    }
}
