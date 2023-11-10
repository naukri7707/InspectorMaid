using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public sealed class Column : VisualElement
    {
        public Column(bool reverse = false)
        {
            style.flexDirection = reverse switch
            {
                true => FlexDirection.ColumnReverse,
                false => FlexDirection.Column
            };
        }
    }
}
