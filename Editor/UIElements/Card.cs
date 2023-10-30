using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public sealed class Card : VisualElement
    {
        public Card() : this(new Color32(56, 56, 56, 255))
        {

        }

        public Card(Color cardColor)
        {
            var outlineColor = new Color(cardColor.r / 2F, cardColor.g / 2F, cardColor.b / 2F, 255);
            var shadowColor = new Color(cardColor.r / 3F, cardColor.g / 3F, cardColor.b / 3F, 255);

            style.SetMarginSymmetric(vertical: 4);
            style.SetPaddingSymmetric(vertical: 6, horizontal: 4);

            style.backgroundColor = cardColor;
            style.SetBorderRadiusAll(4);

            // outline
            style.SetBorderWidthOnly(top: 1F, left: 1F);
            style.SetBorderColorOnly(top: outlineColor, left: outlineColor);

            // shadow
            style.SetBorderWidthOnly(right: 2F, bottom: 2F);
            style.SetBorderColorOnly(right: shadowColor, bottom: shadowColor);
        }
    }
}