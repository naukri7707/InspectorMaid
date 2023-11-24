using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements.Compose
{
    [SuppressMessage("Style", "IDE1006")]
    public readonly struct ComposerOf<T> where T : VisualElement
    {
        public ComposerOf(T visualElement)
        {
            element = visualElement;
        }

        public readonly T element;

        public string name
        {
            get => element.name;
            set => element.name = value;
        }

        public bool enabled
        {
            get => element.enabledSelf;
            set => element.SetEnabled(value);
        }

        public string tooltip
        {
            get => element.tooltip;
            set => element.tooltip = value;
        }

        public ClassList classList
        {
            set
            {
                foreach (var className in value.classNames)
                {
                    element.AddToClassList(className);
                }
            }
        }

        public VisualElement[] children
        {
            get => element.Children().ToArray();
            set
            {
                element.Clear();
                foreach (var child in value)
                {
                    element.Add(child);
                }
            }
        }

        public Border border
        {
            get
            {
                return Border.Only(
                    top: new BorderSide(style.borderTopColor, style.borderTopWidth),
                    right: new BorderSide(style.borderRightColor, style.borderRightWidth),
                    bottom: new BorderSide(style.borderBottomColor, style.borderBottomWidth),
                    left: new BorderSide(style.borderLeftColor, style.borderLeftWidth)
                );
            }
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
            get
            {
                return BorderRadius.Only(
                    topLeft: style.borderTopLeftRadius,
                    topRight: style.borderTopRightRadius,
                    bottomLeft: style.borderBottomLeftRadius,
                    bottomRight: style.borderBottomRightRadius
                    );
            }
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
            get
            {
                return EdgeInsets.Only(
                    top: style.top,
                    right: style.right,
                    bottom: style.bottom,
                    left: style.left
                    );
            }
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
            get
            {
                return EdgeInsets.Only(
                    top: style.marginTop,
                    right: style.marginRight,
                    bottom: style.marginBottom,
                    left: style.marginLeft
                    );
            }
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
            get
            {
                return EdgeInsets.Only(
                    top: style.paddingTop,
                    right: style.paddingRight,
                    bottom: style.paddingBottom,
                    left: style.paddingLeft
                    );
            }
            set
            {
                style.paddingTop = value.top ?? style.paddingTop;
                style.paddingRight = value.right ?? style.paddingRight;
                style.paddingBottom = value.bottom ?? style.paddingBottom;
                style.paddingLeft = value.left ?? style.paddingLeft;
            }
        }

        private IStyle style => element.style;

        public void On<TEventType>(EventCallback<TEventType> callback, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown) where TEventType : EventBase<TEventType>, new()
        {
            element.RegisterCallback(callback, useTrickleDown);
        }

        #region -- Direct Style --

        public StyleEnum<Align> alignContent { get => style.alignContent; set => style.alignContent = value; }

        public StyleEnum<Align> alignItems { get => style.alignItems; set => style.alignItems = value; }

        public StyleEnum<Align> alignSelf { get => style.alignSelf; set => style.alignSelf = value; }

        public StyleColor backgroundColor { get => style.backgroundColor; set => style.backgroundColor = value; }

        public StyleBackground backgroundImage { get => style.backgroundImage; set => style.backgroundImage = value; }

        public StyleBackgroundPosition backgroundPositionX { get => style.backgroundPositionX; set => style.backgroundPositionX = value; }

        public StyleBackgroundPosition backgroundPositionY { get => style.backgroundPositionY; set => style.backgroundPositionY = value; }

        public StyleBackgroundRepeat backgroundRepeat { get => style.backgroundRepeat; set => style.backgroundRepeat = value; }

        public StyleBackgroundSize backgroundSize { get => style.backgroundSize; set => style.backgroundSize = value; }

        public StyleLength fontSize { get => style.fontSize; set => style.fontSize = value; }

        public StyleColor color { get => style.color; set => style.color = value; }

        public StyleCursor cursor { get => style.cursor; set => style.cursor = value; }

        public StyleEnum<DisplayStyle> display { get => style.display; set => style.display = value; }

        public StyleLength flexBasis { get => style.flexBasis; set => style.flexBasis = value; }

        public StyleEnum<FlexDirection> flexDirection { get => style.flexDirection; set => style.flexDirection = value; }

        public StyleFloat flexGrow { get => style.flexGrow; set => style.flexGrow = value; }

        public StyleFloat flexShrink { get => style.flexShrink; set => style.flexShrink = value; }

        public StyleEnum<Wrap> flexWrap { get => style.flexWrap; set => style.flexWrap = value; }

        public StyleLength height { get => style.height; set => style.height = value; }

        public StyleEnum<Justify> justifyContent { get => style.justifyContent; set => style.justifyContent = value; }

        public StyleLength letterSpacing { get => style.letterSpacing; set => style.letterSpacing = value; }

        public StyleLength maxHeight { get => style.maxHeight; set => style.maxHeight = value; }

        public StyleLength maxWidth { get => style.maxWidth; set => style.maxWidth = value; }

        public StyleLength minHeight { get => style.minHeight; set => style.minHeight = value; }

        public StyleLength minWidth { get => style.minWidth; set => style.minWidth = value; }

        public StyleFloat opacity { get => style.opacity; set => style.opacity = value; }

        public StyleEnum<Overflow> overflow { get => style.overflow; set => style.overflow = value; }

        public StyleEnum<Position> position { get => style.position; set => style.position = value; }

        public StyleRotate rotate { get => style.rotate; set => style.rotate = value; }

        public StyleScale scale { get => style.scale; set => style.scale = value; }

        public StyleEnum<TextOverflow> textOverflow { get => style.textOverflow; set => style.textOverflow = value; }

        public StyleTextShadow textShadow { get => style.textShadow; set => style.textShadow = value; }

        public StyleTransformOrigin transformOrigin { get => style.transformOrigin; set => style.transformOrigin = value; }

        public StyleList<TimeValue> transitionDelay { get => style.transitionDelay; set => style.transitionDelay = value; }

        public StyleList<TimeValue> transitionDuration { get => style.transitionDuration; set => style.transitionDuration = value; }

        public StyleList<StylePropertyName> transitionProperty { get => style.transitionProperty; set => style.transitionProperty = value; }

        public StyleList<EasingFunction> transitionTimingFunction { get => style.transitionTimingFunction; set => style.transitionTimingFunction = value; }

        public StyleTranslate translate { get => style.translate; set => style.translate = value; }

        public StyleColor unityBackgroundImageTintColor { get => style.unityBackgroundImageTintColor; set => style.unityBackgroundImageTintColor = value; }

        public StyleFont unityFont { get => style.unityFont; set => style.unityFont = value; }

        public StyleFontDefinition unityFontDefinition { get => style.unityFontDefinition; set => style.unityFontDefinition = value; }

        public StyleEnum<FontStyle> unityFontStyleAndWeight { get => style.unityFontStyleAndWeight; set => style.unityFontStyleAndWeight = value; }

        public StyleEnum<OverflowClipBox> unityOverflowClipBox { get => style.unityOverflowClipBox; set => style.unityOverflowClipBox = value; }

        public StyleLength unityParagraphSpacing { get => style.unityParagraphSpacing; set => style.unityParagraphSpacing = value; }

        public StyleInt unitySliceBottom { get => style.unitySliceBottom; set => style.unitySliceBottom = value; }

        public StyleInt unitySliceLeft { get => style.unitySliceLeft; set => style.unitySliceLeft = value; }

        public StyleInt unitySliceRight { get => style.unitySliceRight; set => style.unitySliceRight = value; }

        public StyleFloat unitySliceScale { get => style.unitySliceScale; set => style.unitySliceScale = value; }

        public StyleInt unitySliceTop { get => style.unitySliceTop; set => style.unitySliceTop = value; }

        public StyleEnum<TextAnchor> unityTextAlign { get => style.unityTextAlign; set => style.unityTextAlign = value; }

        public StyleColor unityTextOutlineColor { get => style.unityTextOutlineColor; set => style.unityTextOutlineColor = value; }

        public StyleFloat unityTextOutlineWidth { get => style.unityTextOutlineWidth; set => style.unityTextOutlineWidth = value; }

        public StyleEnum<TextOverflowPosition> unityTextOverflowPosition { get => style.unityTextOverflowPosition; set => style.unityTextOverflowPosition = value; }

        public StyleEnum<Visibility> visibility { get => style.visibility; set => style.visibility = value; }

        public StyleEnum<WhiteSpace> whiteSpace { get => style.whiteSpace; set => style.whiteSpace = value; }

        public StyleLength width { get => style.width; set => style.width = value; }

        public StyleLength wordSpacing { get => style.wordSpacing; set => style.wordSpacing = value; }

        #endregion -- Direct Style --
    }

    public static class ExtensionForComposer
    {
        public static T Compose<T>(this T visualElement, ComposeAction<T> action) where T : VisualElement
        {
            action(new ComposerOf<T>(visualElement));
            return visualElement;
        }

        public delegate void ComposeAction<T>(ComposerOf<T> composer) where T : VisualElement;
    }
}
