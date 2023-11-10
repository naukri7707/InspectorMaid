using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements.Compose
{
    public readonly struct EdgeInsets
    {
        public EdgeInsets(StyleLength? top, StyleLength? right, StyleLength? bottom, StyleLength? left)
        {
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.left = left;
        }

        public readonly StyleLength? top;

        public readonly StyleLength? right;

        public readonly StyleLength? bottom;

        public readonly StyleLength? left;

        public static EdgeInsets All(StyleLength? all = null)
        {
            return new EdgeInsets(all, all, all, all);
        }

        public static EdgeInsets Symmetric(StyleLength? vertical = null, StyleLength? horizontal = null)
        {
            return new EdgeInsets(vertical, horizontal, vertical, horizontal);
        }

        public static EdgeInsets Only(StyleLength? top = null, StyleLength? right = null, StyleLength? bottom = null, StyleLength? left = null)
        {
            return new EdgeInsets(top, right, bottom, left);
        }
    }
}
