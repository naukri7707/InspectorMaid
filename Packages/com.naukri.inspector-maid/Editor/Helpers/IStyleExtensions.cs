using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public static class IStyleExtensions
    {
        public static void SetBorderWidthAll(this IStyle style, StyleFloat? all = null)
        {
            SetBorderWidthOnly(style, all, all, all, all);
        }

        public static void SetBorderWidthSymmetric(this IStyle style, StyleFloat? vertical = null, StyleFloat? horizontal = null)
        {
            SetBorderWidthOnly(style, vertical, horizontal, vertical, horizontal);
        }

        public static void SetBorderWidthOnly(this IStyle style, StyleFloat? top = null, StyleFloat? right = null, StyleFloat? bottom = null, StyleFloat? left = null)
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

        public static void SetBorderColorAll(this IStyle style, StyleColor? Color = null)
        {
            SetBorderColorOnly(style, Color, Color, Color, Color);
        }

        public static void SetBorderColorSymmetric(this IStyle style, StyleColor? vertical = null, StyleColor? horizontal = null)
        {
            SetBorderColorOnly(style, vertical, horizontal, vertical, horizontal);
        }

        public static void SetBorderColorOnly(this IStyle style, StyleColor? top = null, StyleColor? right = null, StyleColor? bottom = null, StyleColor? left = null)
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

        public static void SetBorderRadiusAll(this IStyle style, StyleLength? all = null)
        {
            SetBorderRadiusOnly(style, all, all, all, all);
        }

        public static void SetBorderRadiusVertical(this IStyle style, StyleLength? top = null, StyleLength? bottom = null)
        {
            SetBorderRadiusOnly(style, top, top, bottom, bottom);
        }

        public static void SetBorderRadiusHorizontal(this IStyle style, StyleLength? left = null, StyleLength? right = null)
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

        public static void SetMarginAll(this IStyle style, StyleLength? all = null)
        {
            SetMarginOnly(style, all, all, all, all);
        }

        public static void SetMarginSymmetric(this IStyle style, StyleLength? vertical = null, StyleLength? horizontal = null)
        {
            SetMarginOnly(style, vertical, horizontal, vertical, horizontal);
        }

        public static void SetMarginOnly(this IStyle style, StyleLength? top = null, StyleLength? right = null, StyleLength? bottom = null, StyleLength? left = null)
        {
            if (top.HasValue)
            {
                style.marginTop = top.Value;
            }
            if (right.HasValue)
            {
                style.marginRight = right.Value;
            }
            if (bottom.HasValue)
            {
                style.marginBottom = bottom.Value;
            }
            if (left.HasValue)
            {
                style.marginLeft = left.Value;
            }
        }

        public static void SetPaddingAll(this IStyle style, StyleLength? all = null)
        {
            SetPaddingOnly(style, all, all, all, all);
        }

        public static void SetPaddingSymmetric(this IStyle style, StyleLength? vertical = null, StyleLength? horizontal = null)
        {
            SetPaddingOnly(style, vertical, horizontal, vertical, horizontal);
        }

        public static void SetPaddingOnly(this IStyle style, StyleLength? top = null, StyleLength? right = null, StyleLength? bottom = null, StyleLength? left = null)
        {
            if (top.HasValue)
            {
                style.paddingTop = top.Value;
            }
            if (right.HasValue)
            {
                style.paddingRight = right.Value;
            }
            if (bottom.HasValue)
            {
                style.paddingBottom = bottom.Value;
            }
            if (left.HasValue)
            {
                style.paddingLeft = left.Value;
            }
        }
    }
}
