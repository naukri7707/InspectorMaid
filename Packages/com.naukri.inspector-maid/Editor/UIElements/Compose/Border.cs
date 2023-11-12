namespace Naukri.InspectorMaid.Editor.UIElements.Compose
{
    public readonly struct Border
    {
        private Border(BorderSide? top, BorderSide? right, BorderSide? bottom, BorderSide? left)
        {
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.left = left;
        }

        public readonly BorderSide? top;

        public readonly BorderSide? right;

        public readonly BorderSide? bottom;

        public readonly BorderSide? left;

        public static Border All(BorderSide? all = null)
        {
            return new Border(all, all, all, all);
        }

        public static Border Symmetric(BorderSide? vertical = null, BorderSide? horizontal = null)
        {
            return new Border(vertical, horizontal, vertical, horizontal);
        }

        public static Border Only(BorderSide? top = null, BorderSide? right = null, BorderSide? bottom = null, BorderSide? left = null)
        {
            return new Border(top, right, bottom, left);
        }
    }
}
