namespace Naukri.InspectorMaid.Helpers
{
    internal static class ConvertedValueSetter
    {
        public static void ByDirection<T>(T[] source, ref T top, ref T right, ref T bottom, ref T left)
        {
            if (source.Length == 1)
            {
                top = right = bottom = left = source[0];
            }
            else if (source.Length == 2)
            {
                top = bottom = source[0];
                right = left = source[1];
            }
            else if (source.Length == 3)
            {
                top = source[0];
                right = left = source[1];
                bottom = source[2];
            }
            else if (source.Length == 4)
            {
                top = source[0];
                right = source[1];
                bottom = source[2];
                left = source[3];
            }
            else
            {
                throw new System.Exception($"Too many parameters to convert.");
            }
        }

        public static void ByCorner<T>(T[] source, ref T topLeft, ref T topRight, ref T bottomLeft, ref T bottomRight)
        {
            if (source.Length == 1)
            {
                topLeft = topRight = bottomLeft = bottomRight = source[0];
            }
            else if (source.Length == 2)
            {
                topLeft = topRight = source[0];
                bottomLeft = bottomRight = source[1];
            }
            else if (source.Length == 3)
            {
                throw new System.Exception($"Can't convert with 3 parameters.");
            }
            else if (source.Length == 4)
            {
                topLeft = source[0];
                topRight = source[1];
                bottomLeft = source[2];
                bottomRight = source[3];
            }
            else
            {
                throw new System.Exception($"Too many parameters to convert.");
            }
        }
    }
}
