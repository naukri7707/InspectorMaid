using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Stylers
{
    public class StyleStyler : StylerOf<StyleAttribute>
    {
        public override void OnStyling(IStyle style)
        {
            style.alignContent = model.alignContent ?? style.alignContent;
            style.alignItems = model.alignItems ?? style.alignItems;
            style.alignSelf = model.alignSelf ?? style.alignSelf;
            style.backgroundColor = model.backgroundColor ?? style.backgroundColor;
            style.backgroundImage = model.backgroundImage ?? style.backgroundImage;
            style.backgroundPositionX = model.backgroundPositionX ?? style.backgroundPositionX;
            style.backgroundPositionY = model.backgroundPositionY ?? style.backgroundPositionY;
            style.backgroundRepeat = model.backgroundRepeat ?? style.backgroundRepeat;
            style.backgroundSize = model.backgroundSize ?? style.backgroundSize;
            style.borderBottomColor = model.borderBottomColor ?? style.borderBottomColor;
            style.borderBottomLeftRadius = model.borderBottomLeftRadius ?? style.borderBottomLeftRadius;
            style.borderBottomRightRadius = model.borderBottomRightRadius ?? style.borderBottomRightRadius;
            style.borderBottomWidth = model.borderBottomWidth ?? style.borderBottomWidth;
            style.borderLeftColor = model.borderLeftColor ?? style.borderLeftColor;
            style.borderLeftWidth = model.borderLeftWidth ?? style.borderLeftWidth;
            style.borderRightColor = model.borderRightColor ?? style.borderRightColor;
            style.borderRightWidth = model.borderRightWidth ?? style.borderRightWidth;
            style.borderTopColor = model.borderTopColor ?? style.borderTopColor;
            style.borderTopLeftRadius = model.borderTopLeftRadius ?? style.borderTopLeftRadius;
            style.borderTopRightRadius = model.borderTopRightRadius ?? style.borderTopRightRadius;
            style.borderTopWidth = model.borderTopWidth ?? style.borderTopWidth;
            style.bottom = model.bottom ?? style.bottom;
            style.color = model.color ?? style.color;
            style.cursor = model.cursor ?? style.cursor;
            style.display = model.display ?? style.display;
            style.flexBasis = model.flexBasis ?? style.flexBasis;
            style.flexDirection = model.flexDirection ?? style.flexDirection;
            style.flexGrow = model.flexGrow ?? style.flexGrow;
            style.flexShrink = model.flexShrink ?? style.flexShrink;
            style.flexWrap = model.flexWrap ?? style.flexWrap;
            style.fontSize = model.fontSize ?? style.fontSize;
            style.height = model.height ?? style.height;
            style.justifyContent = model.justifyContent ?? style.justifyContent;
            style.left = model.left ?? style.left;
            style.letterSpacing = model.letterSpacing ?? style.letterSpacing;
            style.marginBottom = model.marginBottom ?? style.marginBottom;
            style.marginLeft = model.marginLeft ?? style.marginLeft;
            style.marginRight = model.marginRight ?? style.marginRight;
            style.marginTop = model.marginTop ?? style.marginTop;
            style.maxHeight = model.maxHeight ?? style.maxHeight;
            style.maxWidth = model.maxWidth ?? style.maxWidth;
            style.minHeight = model.minHeight ?? style.minHeight;
            style.minWidth = model.minWidth ?? style.minWidth;
            style.opacity = model.opacity ?? style.opacity;
            style.overflow = model.overflow ?? style.overflow;
            style.paddingBottom = model.paddingBottom ?? style.paddingBottom;
            style.paddingLeft = model.paddingLeft ?? style.paddingLeft;
            style.paddingRight = model.paddingRight ?? style.paddingRight;
            style.paddingTop = model.paddingTop ?? style.paddingTop;
            style.position = model.position ?? style.position;
            style.right = model.right ?? style.right;
            style.rotate = model.rotate ?? style.rotate;
            style.scale = model.scale ?? style.scale;
            style.textOverflow = model.textOverflow ?? style.textOverflow;
            style.textShadow = model.textShadow ?? style.textShadow;
            style.top = model.top ?? style.top;
            style.transformOrigin = model.transformOrigin ?? style.transformOrigin;
            style.transitionDelay = model.transitionDelay ?? style.transitionDelay;
            style.transitionDuration = model.transitionDuration ?? style.transitionDuration;
            style.transitionProperty = model.transitionProperty ?? style.transitionProperty;
            style.transitionTimingFunction = model.transitionTimingFunction ?? style.transitionTimingFunction;
            style.translate = model.translate ?? style.translate;
            style.unityBackgroundImageTintColor = model.unityBackgroundImageTintColor ?? style.unityBackgroundImageTintColor;
            style.unityFont = model.unityFont ?? style.unityFont;
            style.unityFontDefinition = model.unityFontDefinition ?? style.unityFontDefinition;
            style.unityFontStyleAndWeight = model.unityFontStyleAndWeight ?? style.unityFontStyleAndWeight;
            style.unityOverflowClipBox = model.unityOverflowClipBox ?? style.unityOverflowClipBox;
            style.unityParagraphSpacing = model.unityParagraphSpacing ?? style.unityParagraphSpacing;
            style.unitySliceBottom = model.unitySliceBottom ?? style.unitySliceBottom;
            style.unitySliceLeft = model.unitySliceLeft ?? style.unitySliceLeft;
            style.unitySliceRight = model.unitySliceRight ?? style.unitySliceRight;
            style.unitySliceScale = model.unitySliceScale ?? style.unitySliceScale;
            style.unitySliceTop = model.unitySliceTop ?? style.unitySliceTop;
            style.unityTextAlign = model.unityTextAlign ?? style.unityTextAlign;
            style.unityTextOutlineColor = model.unityTextOutlineColor ?? style.unityTextOutlineColor;
            style.unityTextOutlineWidth = model.unityTextOutlineWidth ?? style.unityTextOutlineWidth;
            style.unityTextOverflowPosition = model.unityTextOverflowPosition ?? style.unityTextOverflowPosition;
            style.visibility = model.visibility ?? style.visibility;
            style.whiteSpace = model.whiteSpace ?? style.whiteSpace;
            style.width = model.width ?? style.width;
            style.wordSpacing = model.wordSpacing ?? style.wordSpacing;
        }
    }
}
