using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public sealed class Column : VisualElement
    {
        public Column() : this(false)
        {
        }

        public Column(bool reverse)
        {
            style.flexDirection = reverse switch
            {
                true => FlexDirection.ColumnReverse,
                false => FlexDirection.Column
            };
        }
    }
}
