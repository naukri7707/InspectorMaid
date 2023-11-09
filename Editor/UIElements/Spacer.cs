using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public class Spacer : VisualElement
    {
        public Spacer(float flexGrow = 1)
        {
            style.flexGrow = flexGrow;
        }
    }
}
