using Naukri.InspectorMaid.Converters;
using Naukri.InspectorMaid.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid
{
    public class SpacerAttribute : ItemAttribute
    {
        public SpacerAttribute(string flexGrow = "1")
        {
            this.flexGrow = StyleStringConverter.ToStyleFloat(flexGrow) ?? this.flexGrow;
        }

        public readonly StyleFloat? flexGrow;
    }
}
