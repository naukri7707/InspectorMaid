using Naukri.InspectorMaid.Converters;
using Naukri.InspectorMaid.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Style
{
    public class BorderColorAttribute : StylerAttribute
    {
        public BorderColorAttribute(string all = null)
            : this(all, all, all, all)
        {
            var allColor = StringConverter.ToStyleColor(all);

            top = right = bottom = left = allColor;
        }

        public BorderColorAttribute(
            string vertical = null,
            string horizontal = null
            )
        {
            var verticalColor = StringConverter.ToStyleColor(vertical);
            var horizontalColor = StringConverter.ToStyleColor(horizontal);

            top = bottom = verticalColor;
            right = left = horizontalColor;
        }

        public BorderColorAttribute(
            string top = null,
            string right = null,
            string bottom = null,
            string left = null
            )
        {
            this.top = StringConverter.ToStyleColor(top);
            this.right = StringConverter.ToStyleColor(right);
            this.bottom = StringConverter.ToStyleColor(bottom);
            this.left = StringConverter.ToStyleColor(left);
        }

        public readonly StyleColor top;

        public readonly StyleColor right;

        public readonly StyleColor bottom;

        public readonly StyleColor left;
    }
}
