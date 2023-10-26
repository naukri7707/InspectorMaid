using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class StyleStyler : CustomStylerOf<StyleAttribute>
    {
        public override void OnStyling(IStyle style)
        {
            style.alignContent = attribute.alignContent ?? style.alignContent;
            style.alignItems = attribute.alignItems ?? style.alignItems;
            style.alignSelf = attribute.alignSelf ?? style.alignSelf;
            style.backgroundColor = attribute.backgroundColor ?? style.backgroundColor;
            style.backgroundImage = attribute.backgroundImage ?? style.backgroundImage;
            style.backgroundPositionX = attribute.backgroundPositionX ?? style.backgroundPositionX;
            style.backgroundPositionY = attribute.backgroundPositionY ?? style.backgroundPositionY;
            style.backgroundRepeat = attribute.backgroundRepeat ?? style.backgroundRepeat;
            style.backgroundSize = attribute.backgroundSize ?? style.backgroundSize;
            style.borderBottomColor = attribute.borderBottomColor ?? style.borderBottomColor;
            style.borderBottomLeftRadius = attribute.borderBottomLeftRadius ?? style.borderBottomLeftRadius;
            style.borderBottomRightRadius = attribute.borderBottomRightRadius ?? style.borderBottomRightRadius;
            style.borderBottomWidth = attribute.borderBottomWidth ?? style.borderBottomWidth;
            style.borderLeftColor = attribute.borderLeftColor ?? style.borderLeftColor;
            style.borderLeftWidth = attribute.borderLeftWidth ?? style.borderLeftWidth;
            style.borderRightColor = attribute.borderRightColor ?? style.borderRightColor;
            style.borderRightWidth = attribute.borderRightWidth ?? style.borderRightWidth;
            style.borderTopColor = attribute.borderTopColor ?? style.borderTopColor;
            style.borderTopLeftRadius = attribute.borderTopLeftRadius ?? style.borderTopLeftRadius;
            style.borderTopRightRadius = attribute.borderTopRightRadius ?? style.borderTopRightRadius;
            style.borderTopWidth = attribute.borderTopWidth ?? style.borderTopWidth;
            style.bottom = attribute.bottom ?? style.bottom;
            style.color = attribute.color ?? style.color;
            style.cursor = attribute.cursor ?? style.cursor;
            style.display = attribute.display ?? style.display;
            style.flexBasis = attribute.flexBasis ?? style.flexBasis;
            style.flexDirection = attribute.flexDirection ?? style.flexDirection;
            style.flexGrow = attribute.flexGrow ?? style.flexGrow;
            style.flexShrink = attribute.flexShrink ?? style.flexShrink;
            style.flexWrap = attribute.flexWrap ?? style.flexWrap;
            style.fontSize = attribute.fontSize ?? style.fontSize;
            style.height = attribute.height ?? style.height;
            style.justifyContent = attribute.justifyContent ?? style.justifyContent;
            style.left = attribute.left ?? style.left;
            style.letterSpacing = attribute.letterSpacing ?? style.letterSpacing;
            style.marginBottom = attribute.marginBottom ?? style.marginBottom;
            style.marginLeft = attribute.marginLeft ?? style.marginLeft;
            style.marginRight = attribute.marginRight ?? style.marginRight;
            style.marginTop = attribute.marginTop ?? style.marginTop;
            style.maxHeight = attribute.maxHeight ?? style.maxHeight;
            style.maxWidth = attribute.maxWidth ?? style.maxWidth;
            style.minHeight = attribute.minHeight ?? style.minHeight;
            style.minWidth = attribute.minWidth ?? style.minWidth;
            style.opacity = attribute.opacity ?? style.opacity;
            style.overflow = attribute.overflow ?? style.overflow;
            style.paddingBottom = attribute.paddingBottom ?? style.paddingBottom;
            style.paddingLeft = attribute.paddingLeft ?? style.paddingLeft;
            style.paddingRight = attribute.paddingRight ?? style.paddingRight;
            style.paddingTop = attribute.paddingTop ?? style.paddingTop;
            style.position = attribute.position ?? style.position;
            style.right = attribute.right ?? style.right;
            style.rotate = attribute.rotate ?? style.rotate;
            style.scale = attribute.scale ?? style.scale;
            style.textOverflow = attribute.textOverflow ?? style.textOverflow;
            style.textShadow = attribute.textShadow ?? style.textShadow;
            style.top = attribute.top ?? style.top;
            style.transformOrigin = attribute.transformOrigin ?? style.transformOrigin;
            style.transitionDelay = attribute.transitionDelay ?? style.transitionDelay;
            style.transitionDuration = attribute.transitionDuration ?? style.transitionDuration;
            style.transitionProperty = attribute.transitionProperty ?? style.transitionProperty;
            style.transitionTimingFunction = attribute.transitionTimingFunction ?? style.transitionTimingFunction;
            style.translate = attribute.translate ?? style.translate;
            style.unityBackgroundImageTintColor = attribute.unityBackgroundImageTintColor ?? style.unityBackgroundImageTintColor;
            style.unityFont = attribute.unityFont ?? style.unityFont;
            style.unityFontDefinition = attribute.unityFontDefinition ?? style.unityFontDefinition;
            style.unityFontStyleAndWeight = attribute.unityFontStyleAndWeight ?? style.unityFontStyleAndWeight;
            style.unityOverflowClipBox = attribute.unityOverflowClipBox ?? style.unityOverflowClipBox;
            style.unityParagraphSpacing = attribute.unityParagraphSpacing ?? style.unityParagraphSpacing;
            style.unitySliceBottom = attribute.unitySliceBottom ?? style.unitySliceBottom;
            style.unitySliceLeft = attribute.unitySliceLeft ?? style.unitySliceLeft;
            style.unitySliceRight = attribute.unitySliceRight ?? style.unitySliceRight;
            style.unitySliceScale = attribute.unitySliceScale ?? style.unitySliceScale;
            style.unitySliceTop = attribute.unitySliceTop ?? style.unitySliceTop;
            style.unityTextAlign = attribute.unityTextAlign ?? style.unityTextAlign;
            style.unityTextOutlineColor = attribute.unityTextOutlineColor ?? style.unityTextOutlineColor;
            style.unityTextOutlineWidth = attribute.unityTextOutlineWidth ?? style.unityTextOutlineWidth;
            style.unityTextOverflowPosition = attribute.unityTextOverflowPosition ?? style.unityTextOverflowPosition;
            style.visibility = attribute.visibility ?? style.visibility;
            style.whiteSpace = attribute.whiteSpace ?? style.whiteSpace;
            style.width = attribute.width ?? style.width;
            style.wordSpacing = attribute.wordSpacing ?? style.wordSpacing;
        }
    }
}
