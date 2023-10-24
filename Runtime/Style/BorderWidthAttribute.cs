using Naukri.InspectorMaid.Converters;
using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Helpers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Style
{
    public class BorderWidthAttribute : StylerAttribute
    {
        public BorderWidthAttribute(string borderWidth)
        {
            var floats = StringConverter.ToStyleFloats(borderWidth);

            ConvertedValueSetter.ByDirection(floats, ref top, ref right, ref bottom, ref left);
        }

        public BorderWidthAttribute(
            float all = float.NaN
            ) : this(
                all, all, all, all
                )
        { }

        public BorderWidthAttribute(
            float vertical = float.NaN,
            float horizontal = float.NaN
            ) : this(
                vertical, horizontal, vertical, horizontal
                )
        { }

        public BorderWidthAttribute(
            float top = float.NaN,
            float right = float.NaN,
            float bottom = float.NaN,
            float left = float.NaN
            )
        {
            this.top = NullStyle.Float(top);
            this.right = NullStyle.Float(right);
            this.bottom = NullStyle.Float(bottom);
            this.left = NullStyle.Float(left);
        }

        public readonly StyleFloat top;

        public readonly StyleFloat right;

        public readonly StyleFloat bottom;

        public readonly StyleFloat left;
    }
}
