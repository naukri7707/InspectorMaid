using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public sealed class Row : VisualElement
    {
        public Row(bool reverse = false)
        {
            style.flexDirection = reverse switch
            {
                true => FlexDirection.RowReverse,
                false => FlexDirection.Row
            };
        }
    }
}
