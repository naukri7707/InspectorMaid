using Naukri.InspectorMaid.Editor.Extensions;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public partial class Divider : VisualElement
    {
        public Divider() : this(null)
        {
        }

        public Divider(string text)
        {
            this.text = text;

            if (string.IsNullOrEmpty(text))
            {
                style.SetMarginSymmetric(vertical: 5);
                style.flexDirection = FlexDirection.Row;
                style.height = 17;

                var box = new Box();
                box.style.alignSelf = Align.Center;
                box.style.flexGrow = 0.99F;
                box.style.backgroundColor = LineDefaultColor;
                box.style.height = 2;
                Add(box);
            }
            else
            {
                style.SetMarginSymmetric(vertical: 5);
                style.flexDirection = FlexDirection.Row;

                var boxStart = new Box();
                boxStart.style.alignSelf = Align.Center;
                boxStart.style.width = 50;
                boxStart.style.backgroundColor = LineDefaultColor;
                boxStart.style.height = 2;

                var label = new Label(text);
                label.style.color = LineDefaultColor;
                label.style.flexGrow = 0.01F;
                label.style.fontSize = 14;
                label.style.unityTextAlign = TextAnchor.MiddleCenter;
                label.style.unityFontStyleAndWeight = FontStyle.Bold;

                var boxEnd = new Box();
                boxEnd.style.alignSelf = Align.Center;
                boxEnd.style.flexGrow = 0.99F;
                boxEnd.style.backgroundColor = LineDefaultColor;
                boxEnd.style.height = 2;

                Add(boxStart);
                Add(label);
                Add(boxEnd);
            }
        }

        public string text;
    }

    partial class Divider
    {
        public static StyleColor LineDefaultColor => new(new Color32(128, 128, 128, 255));
    }
}
