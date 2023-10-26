using Naukri.InspectorMaid.Converters;
using Naukri.InspectorMaid.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Style
{
    public class BackgroundColorAttribute : StylerAttribute
    {
        public BackgroundColorAttribute(string color = null)
        {
            backgroundColor = StringConverter.ToStyleColor(color);
        }

        public readonly StyleColor backgroundColor;
    }
}
