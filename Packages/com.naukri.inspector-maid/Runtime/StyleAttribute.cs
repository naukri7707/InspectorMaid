using Naukri.InspectorMaid.Converters;
using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Helpers;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid
{
    public sealed class StyleAttribute : WidgetAttribute
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
                var borderRadiusValues = StringConverter.ToStyleLengths(borderRadius);
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
                var borderRadiusAllValue = StringConverter.ToStyleLength(borderRadiusTop);
                this.borderTopLeftRadius = borderRadiusAllValue;
                this.borderTopRightRadius = borderRadiusAllValue;
                this.borderBottomLeftRadius = borderRadiusAllValue;
                this.borderBottomRightRadius = borderRadiusAllValue;
            }
            if (borderRadiusTop != null)
            {
                var borderRadiusTopValue = StringConverter.ToStyleLength(borderRadiusTop);
                if (borderRadiusTopValue != null)
                {
                    this.borderTopLeftRadius = borderRadiusTopValue;
                    this.borderTopRightRadius = borderRadiusTopValue;
                }
            }
            if (borderRadiusRight != null)
            {
                var borderRadiusRightValue = StringConverter.ToStyleLength(borderRadiusRight);
                if (borderRadiusRightValue != null)
                {
                    this.borderTopRightRadius = borderRadiusRightValue;
                    this.borderBottomRightRadius = borderRadiusRightValue;
                }
            }
            if (borderRadiusBottom != null)
            {
                var borderRadiusBottomValue = StringConverter.ToStyleLength(borderRadiusBottom);
                if (borderRadiusBottomValue != null)
                {
                    this.borderBottomLeftRadius = borderRadiusBottomValue;
                    this.borderBottomRightRadius = borderRadiusBottomValue;
                }
            }
            if (borderRadiusLeft != null)
            {
                var borderRadiusLeftValue = StringConverter.ToStyleLength(borderRadiusLeft);
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
                var borderWidthValues = StringConverter.ToStyleFloats(borderWidth);
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
                var borderWidthllValue = StringConverter.ToStyleFloat(borderWidthAll);
                this.borderTopWidth = borderWidthllValue;
                this.borderRightWidth = borderWidthllValue;
                this.borderBottomWidth = borderWidthllValue;
                this.borderLeftWidth = borderWidthllValue;
            }
            if (borderWidthVertical != null)
            {
                var borderWidthVerticalValue = StringConverter.ToStyleFloat(borderWidthVertical);
                if (borderWidthVerticalValue != null)
                {
                    this.borderTopWidth = borderWidthVerticalValue;
                    this.borderBottomWidth = borderWidthVerticalValue;
                }
            }
            if (borderWidthHorizontal != null)
            {
                var borderWidthHorizontalValue = StringConverter.ToStyleFloat(borderWidthVertical);
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
                var marginValues = StringConverter.ToStyleLengths(margin);
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
                var marginAllValues = StringConverter.ToStyleLength(marginAll);
                this.marginTop = marginAllValues;
                this.marginRight = marginAllValues;
                this.marginBottom = marginAllValues;
                this.marginLeft = marginAllValues;
            }
            if (marginVertical != null)
            {
                var marginVerticalValue = StringConverter.ToStyleLength(marginVertical);
                if (marginVerticalValue != null)
                {
                    this.marginTop = marginVerticalValue;
                    this.marginBottom = marginVerticalValue;
                }
            }
            if (marginHorizontal != null)
            {
                var marginHorizontalValue = StringConverter.ToStyleLength(marginVertical);
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
                var paddingValues = StringConverter.ToStyleLengths(padding);
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
                var paddingAllValues = StringConverter.ToStyleLength(paddingAll);
                this.paddingTop = paddingAllValues;
                this.paddingRight = paddingAllValues;
                this.paddingBottom = paddingAllValues;
                this.paddingLeft = paddingAllValues;
            }
            if (paddingVertical != null)
            {
                var paddingVerticalValue = StringConverter.ToStyleLength(paddingVertical);
                if (paddingVerticalValue != null)
                {
                    this.paddingTop = paddingVerticalValue;
                    this.paddingBottom = paddingVerticalValue;
                }
            }
            if (paddingHorizontal != null)
            {
                var paddingHorizontalValue = StringConverter.ToStyleLength(paddingVertical);
                if (paddingHorizontalValue != null)
                {
                    this.paddingLeft = paddingHorizontalValue;
                    this.paddingRight = paddingHorizontalValue;
                }
            }

            #endregion -- Padding --

            #region -- Direct Setter --

            this.alignContent = StringConverter.ToStyleEnum<Align>(alignContent) ?? this.alignContent;
            this.alignItems = StringConverter.ToStyleEnum<Align>(alignItems) ?? this.alignItems;
            this.alignSelf = StringConverter.ToStyleEnum<Align>(alignSelf) ?? this.alignSelf;
            this.backgroundColor = StringConverter.ToStyleColor(backgroundColor) ?? this.backgroundColor;
            this.backgroundImage = null;
            this.backgroundPositionX = null;
            this.backgroundPositionY = null;
            this.backgroundRepeat = null;
            this.backgroundSize = null;
            this.borderBottomColor = StringConverter.ToStyleColor(borderBottomColor) ?? this.borderBottomColor;
            this.borderBottomLeftRadius = StringConverter.ToStyleLength(borderBottomLeftRadius) ?? this.borderBottomLeftRadius;
            this.borderBottomRightRadius = StringConverter.ToStyleLength(borderBottomRightRadius) ?? this.borderBottomRightRadius;
            this.borderBottomWidth = StringConverter.ToStyleFloat(borderBottomWidth) ?? this.borderBottomWidth;
            this.borderLeftColor = StringConverter.ToStyleColor(borderLeftColor) ?? this.borderLeftColor;
            this.borderLeftWidth = StringConverter.ToStyleFloat(borderLeftWidth) ?? this.borderLeftWidth;
            this.borderRightColor = StringConverter.ToStyleColor(borderRightColor) ?? this.borderRightColor;
            this.borderRightWidth = StringConverter.ToStyleFloat(borderRightWidth) ?? this.borderRightWidth;
            this.borderTopColor = StringConverter.ToStyleColor(borderTopColor) ?? this.borderTopColor;
            this.borderTopLeftRadius = StringConverter.ToStyleLength(borderTopLeftRadius) ?? this.borderTopLeftRadius;
            this.borderTopRightRadius = StringConverter.ToStyleLength(borderTopRightRadius) ?? this.borderTopRightRadius;
            this.borderTopWidth = StringConverter.ToStyleFloat(borderTopWidth) ?? this.borderTopWidth;
            this.bottom = StringConverter.ToStyleLength(bottom) ?? this.bottom;
            this.color = StringConverter.ToStyleColor(color) ?? this.color;
            this.cursor = null;
            this.display = StringConverter.ToStyleEnum<DisplayStyle>(display) ?? this.display;
            this.flexBasis = StringConverter.ToStyleLength(flexBasis) ?? this.flexBasis;
            this.flexDirection = StringConverter.ToStyleEnum<FlexDirection>(flexDirection) ?? this.flexDirection;
            this.flexGrow = StringConverter.ToStyleFloat(flexGrow) ?? this.flexGrow;
            this.flexShrink = StringConverter.ToStyleFloat(flexShrink) ?? this.flexShrink;
            this.flexWrap = StringConverter.ToStyleEnum<Wrap>(flexWrap) ?? this.flexWrap;
            this.fontSize = StringConverter.ToStyleLength(fontSize) ?? this.fontSize;
            this.height = StringConverter.ToStyleLength(height) ?? this.height;
            this.justifyContent = StringConverter.ToStyleEnum<Justify>(justifyContent) ?? this.justifyContent;
            this.left = StringConverter.ToStyleLength(left) ?? this.left;
            this.letterSpacing = StringConverter.ToStyleLength(letterSpacing) ?? this.letterSpacing;
            this.marginBottom = StringConverter.ToStyleLength(marginBottom) ?? this.marginBottom;
            this.marginLeft = StringConverter.ToStyleLength(marginLeft) ?? this.marginLeft;
            this.marginRight = StringConverter.ToStyleLength(marginRight) ?? this.marginRight;
            this.marginTop = StringConverter.ToStyleLength(marginTop) ?? this.marginTop;
            this.maxHeight = StringConverter.ToStyleLength(maxHeight) ?? this.maxHeight;
            this.maxWidth = StringConverter.ToStyleLength(maxWidth) ?? this.maxWidth;
            this.minHeight = StringConverter.ToStyleLength(minHeight) ?? this.minHeight;
            this.minWidth = StringConverter.ToStyleLength(minWidth) ?? this.minWidth;
            this.opacity = StringConverter.ToStyleFloat(opacity) ?? this.opacity;
            this.overflow = StringConverter.ToStyleEnum<Overflow>(overflow) ?? this.overflow;
            this.paddingBottom = StringConverter.ToStyleLength(paddingBottom) ?? this.paddingBottom;
            this.paddingLeft = StringConverter.ToStyleLength(paddingLeft) ?? this.paddingLeft;
            this.paddingRight = StringConverter.ToStyleLength(paddingRight) ?? this.paddingRight;
            this.paddingTop = StringConverter.ToStyleLength(paddingTop) ?? this.paddingTop;
            this.position = StringConverter.ToStyleEnum<Position>(position) ?? this.position;
            this.right = StringConverter.ToStyleLength(right) ?? this.right;
            this.rotate = null;
            this.scale = null;
            this.textOverflow = StringConverter.ToStyleEnum<TextOverflow>(textOverflow) ?? this.textOverflow;
            this.textShadow = null;
            this.top = StringConverter.ToStyleLength(top) ?? this.top;
            this.transformOrigin = null;
            this.transitionDelay = null;
            this.transitionDuration = null;
            this.transitionProperty = null;
            this.transitionTimingFunction = null;
            this.translate = null;
            this.unityBackgroundImageTintColor = StringConverter.ToStyleColor(unityBackgroundImageTintColor) ?? this.unityBackgroundImageTintColor;
            this.unityFont = null;
            this.unityFontDefinition = null;
            this.unityFontStyleAndWeight = StringConverter.ToStyleEnum<FontStyle>(unityFontStyleAndWeight) ?? this.unityFontStyleAndWeight;
            this.unityOverflowClipBox = StringConverter.ToStyleEnum<OverflowClipBox>(unityOverflowClipBox) ?? this.unityOverflowClipBox;
            this.unityParagraphSpacing = StringConverter.ToStyleLength(unityParagraphSpacing) ?? this.unityParagraphSpacing;
            this.unitySliceBottom = StringConverter.ToStyleInt(unitySliceBottom) ?? this.unitySliceBottom;
            this.unitySliceLeft = StringConverter.ToStyleInt(unitySliceLeft) ?? this.unitySliceLeft;
            this.unitySliceRight = StringConverter.ToStyleInt(unitySliceRight) ?? this.unitySliceRight;
            this.unitySliceScale = StringConverter.ToStyleFloat(unitySliceScale) ?? this.unitySliceScale;
            this.unitySliceTop = StringConverter.ToStyleInt(unitySliceTop) ?? this.unitySliceTop;
            this.unityTextAlign = StringConverter.ToStyleEnum<TextAnchor>(unityTextAlign) ?? this.unityTextAlign;
            this.unityTextOutlineColor = StringConverter.ToStyleColor(unityTextOutlineColor) ?? this.unityTextOutlineColor;
            this.unityTextOutlineWidth = StringConverter.ToStyleFloat(unityTextOutlineWidth) ?? this.unityTextOutlineWidth;
            this.unityTextOverflowPosition = StringConverter.ToStyleEnum<TextOverflowPosition>(unityTextOverflowPosition) ?? this.unityTextOverflowPosition;
            this.visibility = StringConverter.ToStyleEnum<Visibility>(visibility) ?? this.visibility;
            this.whiteSpace = StringConverter.ToStyleEnum<WhiteSpace>(whiteSpace) ?? this.whiteSpace;
            this.width = StringConverter.ToStyleLength(width) ?? this.width;
            this.wordSpacing = StringConverter.ToStyleLength(wordSpacing) ?? this.wordSpacing;

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
