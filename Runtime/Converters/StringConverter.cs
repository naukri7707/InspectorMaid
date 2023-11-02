using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Converters
{
    internal static class StringConverter
    {
        public static StyleInt? ToStyleInt(string input)
        {
            // Null
            if (input == null)
            {
                return null;
            }

            var valueText = input.Trim().ToLower();

            if (TryConvertToKeyWord(valueText, out var keyword))
            {
                return new StyleInt(keyword);
            }

            if (int.TryParse(valueText, out var value))
            {
                return new StyleInt(value);
            }

            throw new Exception($"Can't convert {input} to {nameof(StyleInt)}");
        }

        public static StyleFloat? ToStyleFloat(string input)
        {
            // Null
            if (input == null)
            {
                return null;
            }

            var valueText = input.Trim().ToLower();

            if (TryConvertToKeyWord(valueText, out var keyword))
            {
                return new StyleFloat(keyword);
            }

            if (float.TryParse(valueText, out var value))
            {
                return new StyleFloat(value);
            }

            throw new Exception($"Can't convert {input} to {nameof(StyleFloat)}");
        }

        public static StyleFloat?[] ToStyleFloats(string input)
        {
            return input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(it => ToStyleFloat(it))
                .ToArray();
        }

        public static StyleLength? ToStyleLength(string input)
        {
            // Null
            if (input == null)
            {
                return null;
            }

            var valueText = input.Trim().ToLower();

            if (TryConvertToKeyWord(valueText, out var keyword))
            {
                return new StyleLength(keyword);
            }
            else if (valueText.EndsWith("px"))
            {
                if (float.TryParse(valueText[..^2], out var value))
                {
                    var length = new Length(value, LengthUnit.Pixel);
                    return new StyleLength(length);
                }
            }
            else if (valueText.EndsWith("%"))
            {
                if (float.TryParse(valueText[..^1], out var value))
                {
                    var length = new Length(value, LengthUnit.Percent);
                    var a = new StyleLength(length);
                    return a;
                }
            }
            else
            {
                if (float.TryParse(valueText, out var value))
                {
                    return new StyleLength(value);
                }
            }

            throw new Exception($"Can't convert {input} to {nameof(StyleLength)}");
        }

        public static StyleLength?[] ToStyleLengths(string input)
        {
            return input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(it => ToStyleLength(it))
                .ToArray();
        }

        public static StyleColor? ToStyleColor(string input)
        {
            // Null
            if (input == null)
            {
                return null;
            }

            // By hex color
            if (ColorUtility.TryParseHtmlString(input, out var color))
            {
                return new StyleColor(color);
            }

            var bytes = input
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(it => byte.Parse(it))
                .ToArray();

            // By RGB
            if (bytes.Length == 3)
            {
                return new StyleColor(new Color32(bytes[0], bytes[1], bytes[2], 255));
            }

            // By RGBA
            if (bytes.Length == 4)
            {
                return new StyleColor(new Color32(bytes[0], bytes[1], bytes[2], bytes[3]));
            }

            throw new Exception($"Can't convert {input} to {nameof(StyleColor)}");
        }

        public static StyleEnum<T>? ToStyleEnum<T>(string input) where T : struct, IConvertible
        {
            if (input == null)
            {
                return null;
            }

            var value = Enum.Parse<T>(input, true);
            return new StyleEnum<T>(value);
        }

        private static bool TryConvertToKeyWord(string input, out StyleKeyword keyword)
        {
            // Since Enum.TryParse will convert number to Enum, so we need to check if the input is number first.
            if (int.TryParse(input, out _))
            {
                keyword = StyleKeyword.Null;
                return false;
            }

            return Enum.TryParse(input, true, out keyword);
        }
    }
}
