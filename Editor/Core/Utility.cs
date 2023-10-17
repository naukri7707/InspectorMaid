using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Core
{
    internal static class Utility
    {
        public static BindingFlags AllAccessFlags => BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
    }
}
