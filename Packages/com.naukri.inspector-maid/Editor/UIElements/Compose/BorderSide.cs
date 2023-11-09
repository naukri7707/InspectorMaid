using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements.Compose
{
    public readonly struct BorderSide
    {
        public BorderSide(StyleColor? color, StyleFloat? width)
        {
            this.color = color;
            this.width = width;
        }

        public readonly StyleColor? color;

        public readonly StyleFloat? width;

        public void Deconstruct(out StyleColor? color, out StyleFloat? width)
        {
            color = this.color;
            width = this.width;
        }
    }
}
