using Naukri.InspectorMaid.Converters;
using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Helpers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Style
{
    public class MarginAttribute : StylerAttribute
    {
        public MarginAttribute(string margin)
        {
            var lengths = StringConverter.ToStyleLengths(margin);

            ConvertedValueSetter.ByDirection(lengths, ref top, ref right, ref bottom, ref left);
        }

        public MarginAttribute(
            float all = float.NaN,
            LengthUnit allUnit = LengthUnit.Pixel
            ) : this(
                all, allUnit,
                all, allUnit,
                all, allUnit,
                all, allUnit
                )
        { }

        public MarginAttribute(
            float vertical = float.NaN, LengthUnit verticalUnit = LengthUnit.Pixel,
            float horizontal = float.NaN, LengthUnit horizontalUnit = LengthUnit.Pixel
            ) : this(
                vertical, verticalUnit,
                horizontal, horizontalUnit,
                vertical, verticalUnit,
                horizontal, horizontalUnit
                )
        { }

        public MarginAttribute(
            float top = float.NaN, LengthUnit topUnit = LengthUnit.Pixel,
            float right = float.NaN, LengthUnit rightUnit = LengthUnit.Pixel,
            float bottom = float.NaN, LengthUnit bottomUnit = LengthUnit.Pixel,
            float left = float.NaN, LengthUnit leftUnit = LengthUnit.Pixel
            )
        {
            this.top = NullStyle.Length(top, topUnit);
            this.right = NullStyle.Length(right, rightUnit);
            this.bottom = NullStyle.Length(bottom, bottomUnit);
            this.left = NullStyle.Length(left, leftUnit);
        }

        public readonly StyleLength top;

        public readonly StyleLength right;

        public readonly StyleLength bottom;

        public readonly StyleLength left;
    }
}
