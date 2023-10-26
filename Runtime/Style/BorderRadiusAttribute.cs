using Naukri.InspectorMaid.Converters;
using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Helpers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Style
{
    public class BorderRadiusAttribute : StylerAttribute
    {
        public BorderRadiusAttribute(string borderRadius)
        {
            var lengths = StringConverter.ToStyleLengths(borderRadius);

            ConvertedValueSetter.ByCorner(lengths, ref topLeft, ref topRight, ref bottomLeft, ref bottomRight);
        }

        public BorderRadiusAttribute(
            float all = float.NaN,
            LengthUnit allUnit = LengthUnit.Pixel
            ) : this(
                all, allUnit,
                all, allUnit,
                all, allUnit,
                all, allUnit
                )
        { }

        public BorderRadiusAttribute(
            float top = float.NaN, LengthUnit topUnit = LengthUnit.Pixel,
            float bottom = float.NaN, LengthUnit bottomUnit = LengthUnit.Pixel
            ) : this(
                top, topUnit,
                top, topUnit,
                bottom, bottomUnit,
                bottom, bottomUnit
                )
        { }

        public BorderRadiusAttribute(
            float topLeft = float.NaN, LengthUnit topLeftUnit = LengthUnit.Pixel,
            float topRight = float.NaN, LengthUnit topRightUnit = LengthUnit.Pixel,
            float bottomLeft = float.NaN, LengthUnit bottomLeftUnit = LengthUnit.Pixel,
            float bottomRight = float.NaN, LengthUnit bottomRightUnit = LengthUnit.Pixel
            )
        {
            this.topLeft = NullStyle.Length(topLeft, topLeftUnit);
            this.topRight = NullStyle.Length(topRight, topRightUnit);
            this.bottomLeft = NullStyle.Length(bottomLeft, bottomLeftUnit);
            this.bottomRight = NullStyle.Length(bottomRight, bottomRightUnit);
        }

        public readonly StyleLength topLeft;

        public readonly StyleLength topRight;

        public readonly StyleLength bottomLeft;

        public readonly StyleLength bottomRight;
    }
}
