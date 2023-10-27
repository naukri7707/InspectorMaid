using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public class Divider : VisualElement
    {
        public readonly StyleColor kColor = new(new Color32(128, 128, 128, 255));

        public string text;

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
                box.style.backgroundColor = kColor;
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
                boxStart.style.backgroundColor = kColor;
                boxStart.style.height = 2;

                var label = new Label(text);
                label.style.color = kColor;
                label.style.flexGrow = 0.01F;
                label.style.fontSize = 14;
                label.style.unityTextAlign = TextAnchor.MiddleCenter;
                label.style.unityFontStyleAndWeight = FontStyle.Bold;

                var boxEnd = new Box();
                boxEnd.style.alignSelf = Align.Center;
                boxEnd.style.flexGrow = 0.99F;
                boxEnd.style.backgroundColor = kColor;
                boxEnd.style.height = 2;

                Add(boxStart);
                Add(label);
                Add(boxEnd);
            }
        }
    }
}
