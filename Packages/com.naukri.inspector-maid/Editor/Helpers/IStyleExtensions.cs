using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public static class IStyleExtensions
    {
        public static void SetBorderWidthAll(this IStyle style, StyleFloat? width)
        {
            SetBorderWidthOnly(style, width, width, width, width);
        }

        public static void SetBorderWidthSymmetric(this IStyle style, StyleFloat? vertical, StyleFloat? horizontal)
        {
            SetBorderWidthOnly(style, vertical, horizontal, vertical, horizontal);
        }

        public static void SetBorderWidthOnly(this IStyle style, StyleFloat? top, StyleFloat? right, StyleFloat? bottom, StyleFloat? left)
        {
            if (top.HasValue)
            {
                style.borderTopWidth = top.Value;
            }
            if (right.HasValue)
            {
                style.borderRightWidth = right.Value;
            }
            if (bottom.HasValue)
            {
                style.borderBottomWidth = bottom.Value;
            }
            if (left.HasValue)
            {
                style.borderLeftWidth = left.Value;
            }
        }

        public static void SetBorderColorAll(this IStyle style, StyleColor? Color)
        {
            SetBorderColorOnly(style, Color, Color, Color, Color);
        }

        public static void SetBorderColorSymmetric(this IStyle style, StyleColor? vertical, StyleColor? horizontal)
        {
            SetBorderColorOnly(style, vertical, horizontal, vertical, horizontal);
        }

        public static void SetBorderColorOnly(this IStyle style, StyleColor? top, StyleColor? right, StyleColor? bottom, StyleColor? left)
        {
            if (top.HasValue)
            {
                style.borderTopColor = top.Value;
            }
            if (right.HasValue)
            {
                style.borderRightColor = right.Value;
            }
            if (bottom.HasValue)
            {
                style.borderBottomColor = bottom.Value;
            }
            if (left.HasValue)
            {
                style.borderLeftColor = left.Value;
            }
        }

        public static void SetBorderRadiusAll(this IStyle style, StyleLength Radius)
        {
            SetBorderRadiusOnly(style, Radius, Radius, Radius, Radius);
        }

        public static void SetBorderRadiusVertical(this IStyle style, StyleLength? top, StyleLength? bottom)
        {
            SetBorderRadiusOnly(style, top, top, bottom, bottom);
        }

        public static void SetBorderRadiusHorizontal(this IStyle style, StyleLength? left, StyleLength? right)
        {
            SetBorderRadiusOnly(style, left, right, left, right);
        }

        public static void SetBorderRadiusOnly(this IStyle style, StyleLength? topLeft = null, StyleLength? topRight = null, StyleLength? bottomLeft = null, StyleLength? bottomRight = null)
        {
            if (topLeft.HasValue)
            {
                style.borderTopLeftRadius = topLeft.Value;
            }
            if (topRight.HasValue)
            {
                style.borderTopRightRadius = topRight.Value;
            }
            if (bottomLeft.HasValue)
            {
                style.borderBottomLeftRadius = bottomLeft.Value;
            }
            if (bottomRight.HasValue)
            {
                style.borderBottomRightRadius = bottomRight.Value;
            }
        }
    }
}
