using Naukri.InspectorMaid.Converters;
using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Helpers;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid
{
    public sealed class StyleAttribute : StylerAttribute
    {
        public StyleAttribute(
            // Class
            string classList = null,
            // Indirect
            // - BorderRadius
            string borderRadius = null,
            string borderRadiusAll = null,
            string borderRadiusTop = null,
            string borderRadiusRight = null,
            string borderRadiusBottom = null,
            string borderRadiusLeft = null,
            // - BorderWidth
            string borderWidth = null,
            string borderWidthAll = null,
            string borderWidthVertical = null,
            string borderWidthHorizontal = null,
            // - Margin
            string margin = null,
            string marginAll = null,
            string marginVertical = null,
            string marginHorizontal = null,
            // - Padding
            string padding = null,
            string paddingAll = null,
            string paddingVertical = null,
            string paddingHorizontal = null,
            // Direct
            string alignContent = null,
            string alignItems = null,
            string alignSelf = null,
            string backgroundColor = null,
            //string backgroundImage = null,
            //string backgroundPositionX = null,
            //string backgroundPositionY = null,
            //string backgroundRepeat = null,
            //string backgroundSize = null,
            string borderBottomColor = null,
            string borderBottomLeftRadius = null,
            string borderBottomRightRadius = null,
            string borderBottomWidth = null,
            string borderLeftColor = null,
            string borderLeftWidth = null,
            string borderRightColor = null,
            string borderRightWidth = null,
            string borderTopColor = null,
            string borderTopLeftRadius = null,
            string borderTopRightRadius = null,
            string borderTopWidth = null,
            string bottom = null,
            string color = null,
            //string cursor = null,
            string display = null,
            string flexBasis = null,
            string flexDirection = null,
            string flexGrow = null,
            string flexShrink = null,
            string flexWrap = null,
            string fontSize = null,
            string height = null,
            string justifyContent = null,
            string left = null,
            string letterSpacing = null,
            string marginBottom = null,
            string marginLeft = null,
            string marginRight = null,
            string marginTop = null,
            string maxHeight = null,
            string maxWidth = null,
            string minHeight = null,
            string minWidth = null,
            string opacity = null,
            string overflow = null,
            string paddingBottom = null,
            string paddingLeft = null,
            string paddingRight = null,
            string paddingTop = null,
            string position = null,
            string right = null,
            //string rotate = null,
            //string scale = null,
            string textOverflow = null,
            //string textShadow = null,
            string top = null,
            //string transformOrigin = null,
            //string transitionDelay = null,
            //string transitionDuration = null,
            //string transitionProperty = null,
            //string transitionTimingFunction = null,
            //string translate = null,
            string unityBackgroundImageTintColor = null,
            //string unityFont = null,
            //string unityFontDefinition = null,
            string unityFontStyleAndWeight = null,
            string unityOverflowClipBox = null,
            string unityParagraphSpacing = null,
            string unitySliceBottom = null,
            string unitySliceLeft = null,
            string unitySliceRight = null,
            string unitySliceScale = null,
            string unitySliceTop = null,
            string unityTextAlign = null,
            string unityTextOutlineColor = null,
            string unityTextOutlineWidth = null,
            string unityTextOverflowPosition = null,
            string visibility = null,
            string whiteSpace = null,
            string width = null,
            string wordSpacing = null
            )
        {
            this.classList = classList is null ? new string[0] : classList.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            #region -- BorderRadius --

            if (borderRadius != null)
            {
                var borderRadiusValues = StyleStringConverter.ToStyleLengths(borderRadius);
                ConvertedValueSetter.ByCorner(
                    borderRadiusValues,
                    ref this.borderTopLeftRadius,
                    ref this.borderTopRightRadius,
                    ref this.borderBottomLeftRadius,
                    ref this.borderBottomRightRadius
                    );
            }
            if (borderRadiusAll != null)
            {
                var borderRadiusAllValue = StyleStringConverter.ToStyleLength(borderRadiusTop);
                this.borderTopLeftRadius = borderRadiusAllValue;
                this.borderTopRightRadius = borderRadiusAllValue;
                this.borderBottomLeftRadius = borderRadiusAllValue;
                this.borderBottomRightRadius = borderRadiusAllValue;
            }
            if (borderRadiusTop != null)
            {
                var borderRadiusTopValue = StyleStringConverter.ToStyleLength(borderRadiusTop);
                if (borderRadiusTopValue != null)
                {
                    this.borderTopLeftRadius = borderRadiusTopValue;
                    this.borderTopRightRadius = borderRadiusTopValue;
                }
            }
            if (borderRadiusRight != null)
            {
                var borderRadiusRightValue = StyleStringConverter.ToStyleLength(borderRadiusRight);
                if (borderRadiusRightValue != null)
                {
                    this.borderTopRightRadius = borderRadiusRightValue;
                    this.borderBottomRightRadius = borderRadiusRightValue;
                }
            }
            if (borderRadiusBottom != null)
            {
                var borderRadiusBottomValue = StyleStringConverter.ToStyleLength(borderRadiusBottom);
                if (borderRadiusBottomValue != null)
                {
                    this.borderBottomLeftRadius = borderRadiusBottomValue;
                    this.borderBottomRightRadius = borderRadiusBottomValue;
                }
            }
            if (borderRadiusLeft != null)
            {
                var borderRadiusLeftValue = StyleStringConverter.ToStyleLength(borderRadiusLeft);
                if (borderRadiusLeftValue != null)
                {
                    this.borderTopLeftRadius = borderRadiusLeftValue;
                    this.borderBottomLeftRadius = borderRadiusLeftValue;
                }
            }

            #endregion -- BorderRadius --

            #region -- BorderWidth --

            if (borderWidth != null)
            {
                var borderWidthValues = StyleStringConverter.ToStyleFloats(borderWidth);
                ConvertedValueSetter.ByDirection(
                    borderWidthValues,
                    ref this.borderTopWidth,
                    ref this.borderRightWidth,
                    ref this.borderBottomWidth,
                    ref this.borderLeftWidth
                    );
            }
            if (borderWidthAll != null)
            {
                var borderWidthllValue = StyleStringConverter.ToStyleFloat(borderWidthAll);
                this.borderTopWidth = borderWidthllValue;
                this.borderRightWidth = borderWidthllValue;
                this.borderBottomWidth = borderWidthllValue;
                this.borderLeftWidth = borderWidthllValue;
            }
            if (borderWidthVertical != null)
            {
                var borderWidthVerticalValue = StyleStringConverter.ToStyleFloat(borderWidthVertical);
                if (borderWidthVerticalValue != null)
                {
                    this.borderTopWidth = borderWidthVerticalValue;
                    this.borderBottomWidth = borderWidthVerticalValue;
                }
            }
            if (borderWidthHorizontal != null)
            {
                var borderWidthHorizontalValue = StyleStringConverter.ToStyleFloat(borderWidthVertical);
                if (borderWidthHorizontalValue != null)
                {
                    this.borderLeftWidth = borderWidthHorizontalValue;
                    this.borderRightWidth = borderWidthHorizontalValue;
                }
            }

            #endregion -- BorderWidth --

            #region -- Margin --

            if (margin != null)
            {
                var marginValues = StyleStringConverter.ToStyleLengths(margin);
                ConvertedValueSetter.ByDirection(
                    marginValues,
                    ref this.marginTop,
                    ref this.marginRight,
                    ref this.marginBottom,
                    ref this.marginLeft
                    );
            }
            if (marginAll != null)
            {
                var marginAllValues = StyleStringConverter.ToStyleLength(marginAll);
                this.marginTop = marginAllValues;
                this.marginRight = marginAllValues;
                this.marginBottom = marginAllValues;
                this.marginLeft = marginAllValues;
            }
            if (marginVertical != null)
            {
                var marginVerticalValue = StyleStringConverter.ToStyleLength(marginVertical);
                if (marginVerticalValue != null)
                {
                    this.marginTop = marginVerticalValue;
                    this.marginBottom = marginVerticalValue;
                }
            }
            if (marginHorizontal != null)
            {
                var marginHorizontalValue = StyleStringConverter.ToStyleLength(marginVertical);
                if (marginHorizontalValue != null)
                {
                    this.marginLeft = marginHorizontalValue;
                    this.marginRight = marginHorizontalValue;
                }
            }

            #endregion -- Margin --

            #region -- Padding --

            if (padding != null)
            {
                var paddingValues = StyleStringConverter.ToStyleLengths(padding);
                ConvertedValueSetter.ByDirection(
                    paddingValues,
                    ref this.paddingTop,
                    ref this.paddingRight,
                    ref this.paddingBottom,
                    ref this.paddingLeft
                    );
            }
            if (paddingAll != null)
            {
                var paddingAllValues = StyleStringConverter.ToStyleLength(paddingAll);
                this.paddingTop = paddingAllValues;
                this.paddingRight = paddingAllValues;
                this.paddingBottom = paddingAllValues;
                this.paddingLeft = paddingAllValues;
            }
            if (paddingVertical != null)
            {
                var paddingVerticalValue = StyleStringConverter.ToStyleLength(paddingVertical);
                if (paddingVerticalValue != null)
                {
                    this.paddingTop = paddingVerticalValue;
                    this.paddingBottom = paddingVerticalValue;
                }
            }
            if (paddingHorizontal != null)
            {
                var paddingHorizontalValue = StyleStringConverter.ToStyleLength(paddingVertical);
                if (paddingHorizontalValue != null)
                {
                    this.paddingLeft = paddingHorizontalValue;
                    this.paddingRight = paddingHorizontalValue;
                }
            }

            #endregion -- Padding --

            #region -- Direct Setter --

            this.alignContent = StyleStringConverter.ToStyleEnum<Align>(alignContent) ?? this.alignContent;
            this.alignItems = StyleStringConverter.ToStyleEnum<Align>(alignItems) ?? this.alignItems;
            this.alignSelf = StyleStringConverter.ToStyleEnum<Align>(alignSelf) ?? this.alignSelf;
            this.backgroundColor = StyleStringConverter.ToStyleColor(backgroundColor) ?? this.backgroundColor;
            this.backgroundImage = null;
            this.backgroundPositionX = null;
            this.backgroundPositionY = null;
            this.backgroundRepeat = null;
            this.backgroundSize = null;
            this.borderBottomColor = StyleStringConverter.ToStyleColor(borderBottomColor) ?? this.borderBottomColor;
            this.borderBottomLeftRadius = StyleStringConverter.ToStyleLength(borderBottomLeftRadius) ?? this.borderBottomLeftRadius;
            this.borderBottomRightRadius = StyleStringConverter.ToStyleLength(borderBottomRightRadius) ?? this.borderBottomRightRadius;
            this.borderBottomWidth = StyleStringConverter.ToStyleFloat(borderBottomWidth) ?? this.borderBottomWidth;
            this.borderLeftColor = StyleStringConverter.ToStyleColor(borderLeftColor) ?? this.borderLeftColor;
            this.borderLeftWidth = StyleStringConverter.ToStyleFloat(borderLeftWidth) ?? this.borderLeftWidth;
            this.borderRightColor = StyleStringConverter.ToStyleColor(borderRightColor) ?? this.borderRightColor;
            this.borderRightWidth = StyleStringConverter.ToStyleFloat(borderRightWidth) ?? this.borderRightWidth;
            this.borderTopColor = StyleStringConverter.ToStyleColor(borderTopColor) ?? this.borderTopColor;
            this.borderTopLeftRadius = StyleStringConverter.ToStyleLength(borderTopLeftRadius) ?? this.borderTopLeftRadius;
            this.borderTopRightRadius = StyleStringConverter.ToStyleLength(borderTopRightRadius) ?? this.borderTopRightRadius;
            this.borderTopWidth = StyleStringConverter.ToStyleFloat(borderTopWidth) ?? this.borderTopWidth;
            this.bottom = StyleStringConverter.ToStyleLength(bottom) ?? this.bottom;
            this.color = StyleStringConverter.ToStyleColor(color) ?? this.color;
            this.cursor = null;
            this.display = StyleStringConverter.ToStyleEnum<DisplayStyle>(display) ?? this.display;
            this.flexBasis = StyleStringConverter.ToStyleLength(flexBasis) ?? this.flexBasis;
            this.flexDirection = StyleStringConverter.ToStyleEnum<FlexDirection>(flexDirection) ?? this.flexDirection;
            this.flexGrow = StyleStringConverter.ToStyleFloat(flexGrow) ?? this.flexGrow;
            this.flexShrink = StyleStringConverter.ToStyleFloat(flexShrink) ?? this.flexShrink;
            this.flexWrap = StyleStringConverter.ToStyleEnum<Wrap>(flexWrap) ?? this.flexWrap;
            this.fontSize = StyleStringConverter.ToStyleLength(fontSize) ?? this.fontSize;
            this.height = StyleStringConverter.ToStyleLength(height) ?? this.height;
            this.justifyContent = StyleStringConverter.ToStyleEnum<Justify>(justifyContent) ?? this.justifyContent;
            this.left = StyleStringConverter.ToStyleLength(left) ?? this.left;
            this.letterSpacing = StyleStringConverter.ToStyleLength(letterSpacing) ?? this.letterSpacing;
            this.marginBottom = StyleStringConverter.ToStyleLength(marginBottom) ?? this.marginBottom;
            this.marginLeft = StyleStringConverter.ToStyleLength(marginLeft) ?? this.marginLeft;
            this.marginRight = StyleStringConverter.ToStyleLength(marginRight) ?? this.marginRight;
            this.marginTop = StyleStringConverter.ToStyleLength(marginTop) ?? this.marginTop;
            this.maxHeight = StyleStringConverter.ToStyleLength(maxHeight) ?? this.maxHeight;
            this.maxWidth = StyleStringConverter.ToStyleLength(maxWidth) ?? this.maxWidth;
            this.minHeight = StyleStringConverter.ToStyleLength(minHeight) ?? this.minHeight;
            this.minWidth = StyleStringConverter.ToStyleLength(minWidth) ?? this.minWidth;
            this.opacity = StyleStringConverter.ToStyleFloat(opacity) ?? this.opacity;
            this.overflow = StyleStringConverter.ToStyleEnum<Overflow>(overflow) ?? this.overflow;
            this.paddingBottom = StyleStringConverter.ToStyleLength(paddingBottom) ?? this.paddingBottom;
            this.paddingLeft = StyleStringConverter.ToStyleLength(paddingLeft) ?? this.paddingLeft;
            this.paddingRight = StyleStringConverter.ToStyleLength(paddingRight) ?? this.paddingRight;
            this.paddingTop = StyleStringConverter.ToStyleLength(paddingTop) ?? this.paddingTop;
            this.position = StyleStringConverter.ToStyleEnum<Position>(position) ?? this.position;
            this.right = StyleStringConverter.ToStyleLength(right) ?? this.right;
            this.rotate = null;
            this.scale = null;
            this.textOverflow = StyleStringConverter.ToStyleEnum<TextOverflow>(textOverflow) ?? this.textOverflow;
            this.textShadow = null;
            this.top = StyleStringConverter.ToStyleLength(top) ?? this.top;
            this.transformOrigin = null;
            this.transitionDelay = null;
            this.transitionDuration = null;
            this.transitionProperty = null;
            this.transitionTimingFunction = null;
            this.translate = null;
            this.unityBackgroundImageTintColor = StyleStringConverter.ToStyleColor(unityBackgroundImageTintColor) ?? this.unityBackgroundImageTintColor;
            this.unityFont = null;
            this.unityFontDefinition = null;
            this.unityFontStyleAndWeight = StyleStringConverter.ToStyleEnum<FontStyle>(unityFontStyleAndWeight) ?? this.unityFontStyleAndWeight;
            this.unityOverflowClipBox = StyleStringConverter.ToStyleEnum<OverflowClipBox>(unityOverflowClipBox) ?? this.unityOverflowClipBox;
            this.unityParagraphSpacing = StyleStringConverter.ToStyleLength(unityParagraphSpacing) ?? this.unityParagraphSpacing;
            this.unitySliceBottom = StyleStringConverter.ToStyleInt(unitySliceBottom) ?? this.unitySliceBottom;
            this.unitySliceLeft = StyleStringConverter.ToStyleInt(unitySliceLeft) ?? this.unitySliceLeft;
            this.unitySliceRight = StyleStringConverter.ToStyleInt(unitySliceRight) ?? this.unitySliceRight;
            this.unitySliceScale = StyleStringConverter.ToStyleFloat(unitySliceScale) ?? this.unitySliceScale;
            this.unitySliceTop = StyleStringConverter.ToStyleInt(unitySliceTop) ?? this.unitySliceTop;
            this.unityTextAlign = StyleStringConverter.ToStyleEnum<TextAnchor>(unityTextAlign) ?? this.unityTextAlign;
            this.unityTextOutlineColor = StyleStringConverter.ToStyleColor(unityTextOutlineColor) ?? this.unityTextOutlineColor;
            this.unityTextOutlineWidth = StyleStringConverter.ToStyleFloat(unityTextOutlineWidth) ?? this.unityTextOutlineWidth;
            this.unityTextOverflowPosition = StyleStringConverter.ToStyleEnum<TextOverflowPosition>(unityTextOverflowPosition) ?? this.unityTextOverflowPosition;
            this.visibility = StyleStringConverter.ToStyleEnum<Visibility>(visibility) ?? this.visibility;
            this.whiteSpace = StyleStringConverter.ToStyleEnum<WhiteSpace>(whiteSpace) ?? this.whiteSpace;
            this.width = StyleStringConverter.ToStyleLength(width) ?? this.width;
            this.wordSpacing = StyleStringConverter.ToStyleLength(wordSpacing) ?? this.wordSpacing;

            #endregion -- Direct Setter --
        }

        public readonly string[] classList;

        public readonly StyleEnum<Align>? alignContent;

        public readonly StyleEnum<Align>? alignItems;

        public readonly StyleEnum<Align>? alignSelf;

        public readonly StyleColor? backgroundColor;

        public readonly StyleBackground? backgroundImage;

        public readonly StyleBackgroundPosition? backgroundPositionX;

        public readonly StyleBackgroundPosition? backgroundPositionY;

        public readonly StyleBackgroundRepeat? backgroundRepeat;

        public readonly StyleBackgroundSize? backgroundSize;

        public readonly StyleColor? borderBottomColor;

        public readonly StyleLength? borderBottomLeftRadius;

        public readonly StyleLength? borderBottomRightRadius;

        public readonly StyleFloat? borderBottomWidth;

        public readonly StyleColor? borderLeftColor;

        public readonly StyleFloat? borderLeftWidth;

        public readonly StyleColor? borderRightColor;

        public readonly StyleFloat? borderRightWidth;

        public readonly StyleColor? borderTopColor;

        public readonly StyleLength? borderTopLeftRadius;

        public readonly StyleLength? borderTopRightRadius;

        public readonly StyleFloat? borderTopWidth;

        public readonly StyleLength? bottom;

        public readonly StyleColor? color;

        public readonly StyleCursor? cursor;

        public readonly StyleEnum<DisplayStyle>? display;

        public readonly StyleLength? flexBasis;

        public readonly StyleEnum<FlexDirection>? flexDirection;

        public readonly StyleFloat? flexGrow;

        public readonly StyleFloat? flexShrink;

        public readonly StyleEnum<Wrap>? flexWrap;

        public readonly StyleLength? fontSize;

        public readonly StyleLength? height;

        public readonly StyleEnum<Justify>? justifyContent;

        public readonly StyleLength? left;

        public readonly StyleLength? letterSpacing;

        public readonly StyleLength? marginBottom;

        public readonly StyleLength? marginLeft;

        public readonly StyleLength? marginRight;

        public readonly StyleLength? marginTop;

        public readonly StyleLength? maxHeight;

        public readonly StyleLength? maxWidth;

        public readonly StyleLength? minHeight;

        public readonly StyleLength? minWidth;

        public readonly StyleFloat? opacity;

        public readonly StyleEnum<Overflow>? overflow;

        public readonly StyleLength? paddingBottom;

        public readonly StyleLength? paddingLeft;

        public readonly StyleLength? paddingRight;

        public readonly StyleLength? paddingTop;

        public readonly StyleEnum<Position>? position;

        public readonly StyleLength? right;

        public readonly StyleRotate? rotate;

        public readonly StyleScale? scale;

        public readonly StyleEnum<TextOverflow>? textOverflow;

        public readonly StyleTextShadow? textShadow;

        public readonly StyleLength? top;

        public readonly StyleTransformOrigin? transformOrigin;

        public readonly StyleList<TimeValue>? transitionDelay;

        public readonly StyleList<TimeValue>? transitionDuration;

        public readonly StyleList<StylePropertyName>? transitionProperty;

        public readonly StyleList<EasingFunction>? transitionTimingFunction;

        public readonly StyleTranslate? translate;

        public readonly StyleColor? unityBackgroundImageTintColor;

        public readonly StyleFont? unityFont;

        public readonly StyleFontDefinition? unityFontDefinition;

        public readonly StyleEnum<FontStyle>? unityFontStyleAndWeight;

        public readonly StyleEnum<OverflowClipBox>? unityOverflowClipBox;

        public readonly StyleLength? unityParagraphSpacing;

        public readonly StyleInt? unitySliceBottom;

        public readonly StyleInt? unitySliceLeft;

        public readonly StyleInt? unitySliceRight;

        public readonly StyleFloat? unitySliceScale;

        public readonly StyleInt? unitySliceTop;

        public readonly StyleEnum<TextAnchor>? unityTextAlign;

        public readonly StyleColor? unityTextOutlineColor;

        public readonly StyleFloat? unityTextOutlineWidth;

        public readonly StyleEnum<TextOverflowPosition>? unityTextOverflowPosition;

        public readonly StyleEnum<Visibility>? visibility;

        public readonly StyleEnum<WhiteSpace>? whiteSpace;

        public readonly StyleLength? width;

        public readonly StyleLength? wordSpacing;
    }
}
