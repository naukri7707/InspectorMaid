using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class VisualElementExtensions
    {
        public static void SetDisplay(this VisualElement visualElement, bool display)
        {
            visualElement.style.display = display
                ? DisplayStyle.Flex
                : DisplayStyle.None;
        }
    }
}
