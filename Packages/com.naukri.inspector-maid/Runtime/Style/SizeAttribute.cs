using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Helpers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Style
{
    public class SizeAttribute : StylerAttribute
    {
        public SizeAttribute(
            float width = float.NaN, LengthUnit widthUnit = LengthUnit.Pixel,
            float height = float.NaN, LengthUnit heightUnit = LengthUnit.Pixel,
            float minWidth = float.NaN, LengthUnit minWidthUnit = LengthUnit.Pixel,
            float minHeight = float.NaN, LengthUnit minHeightUnit = LengthUnit.Pixel,
            float maxWidth = float.NaN, LengthUnit maxWidthUnit = LengthUnit.Pixel,
            float maxHeight = float.NaN, LengthUnit maxHeightUnit = LengthUnit.Pixel
            )
        {
            this.width = NullStyle.Length(width, widthUnit);
            this.height = NullStyle.Length(height, heightUnit);
            this.minWidth = NullStyle.Length(minWidth, minWidthUnit);
            this.minHeight = NullStyle.Length(minHeight, minHeightUnit);
            this.maxWidth = NullStyle.Length(maxWidth, maxWidthUnit);
            this.maxHeight = NullStyle.Length(maxHeight, maxHeightUnit);
        }

        public readonly StyleLength width;

        public readonly StyleLength height;

        public readonly StyleLength minWidth;

        public readonly StyleLength minHeight;

        public readonly StyleLength maxWidth;

        public readonly StyleLength maxHeight;
    }
}
