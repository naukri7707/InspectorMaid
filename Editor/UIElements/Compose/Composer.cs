using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements.Compose
{
    [SuppressMessage("Style", "IDE1006")]
    public readonly struct Composer
    {
        public Composer(VisualElement visualElement)
        {
            this.visualElement = visualElement;
            style = visualElement.style;
        }

        private readonly VisualElement visualElement;

        private readonly IStyle style;

        public VisualElement[] children
        {
            set
            {
                visualElement.Clear();
                foreach (var child in value)
                {
                    visualElement.Add(child);
                }
            }
        }

        public Border border
        {
            set
            {
                var (topColor, topWidth) = value.top ?? new BorderSide();
                var (rightColor, rightWidth) = value.right ?? new BorderSide();
                var (bottomColor, bottomWidth) = value.bottom ?? new BorderSide();
                var (leftColor, leftWidth) = value.left ?? new BorderSide();

                style.borderTopColor = topColor ?? style.borderTopColor;
                style.borderRightColor = rightColor ?? style.borderRightColor;
                style.borderBottomColor = bottomColor ?? style.borderBottomColor;
                style.borderLeftColor = leftColor ?? style.borderLeftColor;

                style.borderTopWidth = topWidth ?? style.borderTopWidth;
                style.borderRightWidth = rightWidth ?? style.borderRightWidth;
                style.borderBottomWidth = bottomWidth ?? style.borderBottomWidth;
                style.borderLeftWidth = leftWidth ?? style.borderLeftWidth;
            }
        }

        public BorderRadius borderRadius
        {
            set
            {
                style.borderTopLeftRadius = value.topLeft ?? style.borderTopLeftRadius;
                style.borderTopRightRadius = value.topRight ?? style.borderTopRightRadius;
                style.borderBottomLeftRadius = value.bottomLeft ?? style.borderBottomLeftRadius;
                style.borderBottomRightRadius = value.bottomRight ?? style.borderBottomRightRadius;
            }
        }

        public EdgeInsets distanceFromBox
        {
            set
            {
                style.top = value.top ?? style.top;
                style.right = value.right ?? style.right;
                style.bottom = value.bottom ?? style.bottom;
                style.left = value.left ?? style.left;
            }
        }

        public EdgeInsets margin
        {
            set
            {
                style.marginTop = value.top ?? style.marginTop;
                style.marginRight = value.right ?? style.marginRight;
                style.marginBottom = value.bottom ?? style.marginBottom;
                style.marginLeft = value.left ?? style.marginLeft;
            }
        }

        public EdgeInsets padding
        {
            set
            {
                style.paddingTop = value.top ?? style.paddingTop;
                style.paddingRight = value.right ?? style.paddingRight;
                style.paddingBottom = value.bottom ?? style.paddingBottom;
                style.paddingLeft = value.left ?? style.paddingLeft;
            }
        }

        #region -- Direct Style --

        public StyleEnum<Align> alignContent { set { style.alignContent = value; } }

        public StyleEnum<Align> alignItems { set { style.alignItems = value; } }

        public StyleEnum<Align> alignSelf { set { style.alignSelf = value; } }

        public StyleColor backgroundColor { set { style.backgroundColor = value; } }

        public StyleBackground backgroundImage { set { style.backgroundImage = value; } }

        public StyleBackgroundPosition backgroundPositionX { set { style.backgroundPositionX = value; } }

        public StyleBackgroundPosition backgroundPositionY { set { style.backgroundPositionY = value; } }

        public StyleBackgroundRepeat backgroundRepeat { set { style.backgroundRepeat = value; } }

        public StyleBackgroundSize backgroundSize { set { style.backgroundSize = value; } }

        public StyleLength fontSize { set { style.fontSize = value; } }

        public StyleColor color { set { style.color = value; } }

        public StyleCursor cursor { set { style.cursor = value; } }

        public StyleEnum<DisplayStyle> display { set { style.display = value; } }

        public StyleLength flexBasis { set { style.flexBasis = value; } }

        public StyleEnum<FlexDirection> flexDirection { set { style.flexDirection = value; } }

        public StyleFloat flexGrow { set { style.flexGrow = value; } }

        public StyleFloat flexShrink { set { style.flexShrink = value; } }

        public StyleEnum<Wrap> flexWrap { set { style.flexWrap = value; } }

        public StyleLength height { set { style.height = value; } }

        public StyleEnum<Justify> justifyContent { set { style.justifyContent = value; } }

        public StyleLength letterSpacing { set { style.letterSpacing = value; } }

        public StyleLength maxHeight { set { style.maxHeight = value; } }

        public StyleLength maxWidth { set { style.maxWidth = value; } }

        public StyleLength minHeight { set { style.minHeight = value; } }

        public StyleLength minWidth { set { style.minWidth = value; } }

        public StyleFloat opacity { set { style.opacity = value; } }

        public StyleEnum<Overflow> overflow { set { style.overflow = value; } }

        public StyleEnum<Position> position { set { style.position = value; } }

        public StyleRotate rotate { set { style.rotate = value; } }

        public StyleScale scale { set { style.scale = value; } }

        public StyleEnum<TextOverflow> textOverflow { set { style.textOverflow = value; } }

        public StyleTextShadow textShadow { set { style.textShadow = value; } }

        public StyleTransformOrigin transformOrigin { set { style.transformOrigin = value; } }

        public StyleList<TimeValue> transitionDelay { set { style.transitionDelay = value; } }

        public StyleList<TimeValue> transitionDuration { set { style.transitionDuration = value; } }

        public StyleList<StylePropertyName> transitionProperty { set { style.transitionProperty = value; } }

        public StyleList<EasingFunction> transitionTimingFunction { set { style.transitionTimingFunction = value; } }

        public StyleTranslate translate { set { style.translate = value; } }

        public StyleColor unityBackgroundImageTintColor { set { style.unityBackgroundImageTintColor = value; } }

        public StyleFont unityFont { set { style.unityFont = value; } }

        public StyleFontDefinition unityFontDefinition { set { style.unityFontDefinition = value; } }

        public StyleEnum<FontStyle> unityFontStyleAndWeight { set { style.unityFontStyleAndWeight = value; } }

        public StyleEnum<OverflowClipBox> unityOverflowClipBox { set { style.unityOverflowClipBox = value; } }

        public StyleLength unityParagraphSpacing { set { style.unityParagraphSpacing = value; } }

        public StyleInt unitySliceBottom { set { style.unitySliceBottom = value; } }

        public StyleInt unitySliceLeft { set { style.unitySliceLeft = value; } }

        public StyleInt unitySliceRight { set { style.unitySliceRight = value; } }

        public StyleFloat unitySliceScale { set { style.unitySliceScale = value; } }

        public StyleInt unitySliceTop { set { style.unitySliceTop = value; } }

        public StyleEnum<TextAnchor> unityTextAlign { set { style.unityTextAlign = value; } }

        public StyleColor unityTextOutlineColor { set { style.unityTextOutlineColor = value; } }

        public StyleFloat unityTextOutlineWidth { set { style.unityTextOutlineWidth = value; } }

        public StyleEnum<TextOverflowPosition> unityTextOverflowPosition { set { style.unityTextOverflowPosition = value; } }

        public StyleEnum<Visibility> visibility { set { style.visibility = value; } }

        public StyleEnum<WhiteSpace> whiteSpace { set { style.whiteSpace = value; } }

        public StyleLength width { set { style.width = value; } }

        public StyleLength wordSpacing { set { style.wordSpacing = value; } }

        #endregion -- Direct Style --
    }

    public static class VisualElementExtension
    {
        public static T Compose<T>(this T visualElement, ComposeAction action) where T : VisualElement
        {
            action(new Composer(visualElement));
            return visualElement;
        }

        public delegate void ComposeAction(Composer composer);
    }
}
