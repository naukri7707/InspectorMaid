using Naukri.InspectorMaid.Core;
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Style
{
    internal class NotImplementedStyleAttribute : StylerAttribute
    {
        public NotImplementedStyleAttribute()
        {
            throw new NotImplementedException();
        }

        #region -- Align --

        public readonly StyleEnum<Align> alignContent;

        public readonly StyleEnum<Align> alignItems;

        #endregion

        #region -- BackgroundImage --

        public readonly StyleBackground backgroundImage;

        public readonly StyleBackgroundPosition backgroundPositionX;

        public readonly StyleBackgroundPosition backgroundPositionY;

        public readonly StyleBackgroundRepeat backgroundRepeat;

        public readonly StyleBackgroundSize backgroundSize;

        public readonly StyleColor unityBackgroundImageTintColor;

        public readonly StyleInt unitySliceTop;

        public readonly StyleInt unitySliceRight;

        public readonly StyleInt unitySliceBottom;

        public readonly StyleInt unitySliceLeft;

        #endregion -- BackgroundImage --

        #region -- Cursor --

        public readonly StyleCursor cursor;

        #endregion -- Cursor --

        #region -- Flex --

        public readonly StyleLength basis;

        public readonly StyleFloat grow;

        public readonly StyleFloat shrink;

        public readonly StyleEnum<Wrap> flexWrap;

        #endregion

        #region -- Text --

        public readonly StyleColor color;

        public readonly StyleLength fontSize;

        public readonly StyleLength letterSpacing;

        public readonly StyleEnum<TextOverflow> textOverflow;

        public readonly StyleTextShadow textShadow;

        public readonly StyleFont unityFont;

        public readonly StyleFontDefinition unityFontDefinition;

        public readonly StyleEnum<FontStyle> unityFontStyleAndWeight;

        public readonly StyleLength unityParagraphSpacing;

        public readonly StyleEnum<TextAnchor> unityTextAlign;

        public readonly StyleColor unityTextOutlineColor;

        public readonly StyleFloat unityTextOutlineWidth;

        public readonly StyleEnum<TextOverflowPosition> unityTextOverflowPosition;

        public readonly StyleEnum<WhiteSpace> whiteSpace;

        public readonly StyleLength wordSpacing;

        #endregion -- Text --

        #region -- Transition --

        public readonly StyleTransformOrigin transformOrigin;

        public readonly StyleList<TimeValue> transitionDelay;

        public readonly StyleList<TimeValue> transitionDuration;

        public readonly StyleList<StylePropertyName> transitionProperty;

        public readonly StyleList<EasingFunction> transitionTimingFunction;

        public readonly StyleTranslate translate;

        #endregion -- Transition --

        #region -- Other --

        public readonly StyleEnum<DisplayStyle> display;

        public readonly StyleEnum<Justify> justifyContent;

        public readonly StyleFloat opacity;

        public readonly StyleEnum<Overflow> overflow;

        public readonly StyleEnum<Position> position;

        public readonly StyleRotate rotate;

        public readonly StyleScale scale;

        public readonly StyleEnum<OverflowClipBox> unityOverflowClipBox;

        public readonly StyleFloat? unitySliceScale;

        public readonly StyleEnum<Visibility> visibility;

        #endregion -- Other --
    }
}
