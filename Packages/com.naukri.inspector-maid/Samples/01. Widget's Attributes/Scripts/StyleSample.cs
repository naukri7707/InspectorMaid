using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class StyleSample : AttributeSampleBehaviour
    {
        [HelpBox(
@"[Style] is a special attribute used to define the style for lastest declared widget.
you can use 'Named arguments' to define value", HelpBoxMessageType.Info)]

        [HelpBox(
@"Keyword & Enum:
When working with a value that is an enum or uses a style keyword,
you can set the value using the name of the keyword.
However, for safety, I suggest using the nameof expression", HelpBoxMessageType.Info), Style(marginTop: "30")]
        [HelpBox("enum with const string"), Style(flexDirection: "row")]
        [HelpBox("enum with nameof expression"), Style(flexDirection: nameof(FlexDirection.RowReverse))]
        [HelpBox("keyword with const string"), Style(width: "auto")]
        [HelpBox("keyword with nameof expression"), Style(width: nameof(StyleKeyword.None))]
        // Sample 1
        public int enumType = 0;

        [HelpBox(
@"Unit:
If a value has a unit, you can append the unit to the number.
If no unit is added, the default unit will be used.", HelpBoxMessageType.Info), Style(marginTop: "30")]
        [CardScope(color: kSectionBGColor)]
        // Sample 2
        [HelpBox("A 100 width HelpBox (no unit)"), Style(width: "100")]
        [HelpBox("A 100px width HelpBox"), Style(width: "100px")]
        [HelpBox("A 50% width HelpBox"), Style(width: "50%")]
        public int unit = 0;

        [HelpBox(
@"Color:
You can set colors using either hex-color or RGB values, with the alpha value being optional.", HelpBoxMessageType.Info), Style(marginTop: "30")]
        [CardScope(color: kSectionBGColor)]
        // Sample 3
        [ContainerScope, Style(paddingAll: "10", backgroundColor: "#FF0000")] // HexColor without alpha
        [ContainerScope, Style(paddingAll: "10", backgroundColor: "#00FF00AA")] // HexColor with alpha
        [ContainerScope, Style(paddingAll: "10", backgroundColor: "0,0,255")] // RGB value
        [ContainerScope, Style(paddingAll: "10", backgroundColor: "128,128,0,128")] // RGBA value
        public int color = 0;

        [HelpBox(
@"Property conflict:
In cases where properties like margin and padding have multiple values, conflicts can arise.
In such situations, the following principle is followed: the fewer values you change, the higher the priority.
So the priority order is as follows: top/right/bottom/left > vertical/horizontal > all. Consequently,
In this example, the final padding is '40 10 20 10'.", HelpBoxMessageType.Info), Style(marginTop: "30")]
        [CardScope(color: kSectionBGColor)]
        // Sample 4
        [ContainerScope, Style(paddingAll: "10", paddingVertical: "20", paddingTop: "40", backgroundColor: "#FF0000")]
        [Target, Style(backgroundColor: "#000000")]
        public int propertyConflict = 0;

        [HelpBox(
@"Shorthand Property:
In most cases, it's preferable to use as few properties as possible.
You can use shorthand properties to set them, similar to CSS.", HelpBoxMessageType.Info), Style(marginTop: "30")]
        [CardScope(color: kSectionBGColor)]
        // Sample 5
        [ContainerScope, Style(padding: "10", backgroundColor: "#FF0000")] // all
        [ContainerScope, Style(padding: "10 20", backgroundColor: "#00FF00")] // vertical horizontal
        [ContainerScope, Style(padding: "10 20 30", backgroundColor: "#0000FF")] // top horizontal bottom
        [ContainerScope, Style(padding: "10 20 30 40", backgroundColor: "#AAAA00")] // top right bottom left
        [Target, Style(backgroundColor: "#000000")]
        public int shorthandProperty = 0;

        [HelpBox(
@"Class:
You can use classList to load predefined properties, similar to HTML.
If there are two or more classes, use spaces to separate them.", HelpBoxMessageType.Info), Style(marginTop: "30")]
        [HelpBox(
@"Notice that you should import the stylesheet (.uss) by adding it to the inject list at the following location: 'ProjectSetting/Inspector Maid/importStyleSheets.'
In this example, you can import 'SampleStyleSheet.uss,' which is provided in this sample.
If configured correctly, the widget's style will result in a 50% width and a 50px height.", HelpBoxMessageType.Warning)]
        [CardScope(color: kSectionBGColor)]
        // Sample 6
        [ContainerScope, Style(classList: "width-50-percent height-50-px", backgroundColor: "#FF0000")]
        public int usingClasses = 0;
    }
}
