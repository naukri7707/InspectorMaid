using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Helpers
{
    internal static class NullStyle
    {
        //public static StyleColor Color(Color value)
        //{
        //    return new StyleColor(keyword)
        //    {
        //        value = value
        //    };
        //}

        public static StyleFloat Float(float value)
        {
            if (value == float.NaN)
            {
                return new StyleFloat(StyleKeyword.Null);
            }

            return new StyleFloat(value);
        }

        public static StyleLength Length(float value, LengthUnit unit)
        {
            if (value == float.NaN)
            {
                return new StyleLength(StyleKeyword.Null);
            }

            var length = new Length(value, unit);

            return new StyleLength(length);
        }

        //public static StyleEnum<Align> StyleEnumOfAlign(Align value)
        //{
        //    if (value == Align.Auto && keyword == StyleKeyword.Undefined)
        //    {
        //        return new StyleEnum<Align>(StyleKeyword.Null);
        //    }

        //    return new StyleEnum<Align>(keyword)
        //    {
        //        value = value
        //    };
        //}

        //public static StyleEnum<FlexDirection> StyleEnumOfFlexDirection(FlexDirection value, StyleKeyword keyword)
        //{
        //    if (value == FlexDirection.Column && keyword == StyleKeyword.Undefined)
        //    {
        //        return new StyleEnum<FlexDirection>(StyleKeyword.Null);
        //    }

        //    return new StyleEnum<FlexDirection>(keyword)
        //    {
        //        value = value
        //    };
        //}

        //public static StyleEnum<Wrap> StyleEnumOfWrap(Wrap value, StyleKeyword keyword)
        //{
        //    if (value == Wrap.NoWrap && keyword == StyleKeyword.Undefined)
        //    {
        //        return new StyleEnum<Wrap>(StyleKeyword.Null);
        //    }

        //    return new StyleEnum<Wrap>(keyword)
        //    {
        //        value = value
        //    };
        //}
    }
}
