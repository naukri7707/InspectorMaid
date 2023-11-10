using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements.Compose
{
    public readonly struct BorderRadius
    {
        public BorderRadius(StyleLength? topLeft, StyleLength? topRight, StyleLength? bottomLeft, StyleLength? bottomRight)
        {
            this.topLeft = topLeft;
            this.topRight = topRight;
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
        }

        public readonly StyleLength? topLeft;

        public readonly StyleLength? topRight;

        public readonly StyleLength? bottomLeft;

        public readonly StyleLength? bottomRight;

        public static BorderRadius All(StyleLength? all = null)
        {
            return new BorderRadius(all, all, all, all);
        }

        public static BorderRadius Vertical(StyleLength? top = null, StyleLength? bottom = null)
        {
            return new BorderRadius(top, top, bottom, bottom);
        }

        public static BorderRadius Horizontal(StyleLength? left = null, StyleLength? right = null)
        {
            return new BorderRadius(left, right, left, right);
        }

        public static BorderRadius Only(StyleLength? topLeft, StyleLength? topRight, StyleLength? bottomLeft, StyleLength? bottomRight)
        {
            return new BorderRadius(topLeft, topRight, bottomLeft, bottomRight);
        }
    }
}
