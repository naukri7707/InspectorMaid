using Naukri.InspectorMaid.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid
{
    public class ButtonAttribute : BindableDrawerAttribute
    {
        public ButtonAttribute(
            string text = "",
            float width = -1,
            float height = -1,
            FlexDirection flexDirection = FlexDirection.ColumnReverse,
            string binding = null,
            params object[] args
            ) : base(binding, args)
        {
            this.text = text;
            this.width = width;
            this.height = height;
            this.flexDirection = flexDirection;
        }

        public readonly string text;

        public readonly float width;

        public readonly float height;

        public readonly FlexDirection flexDirection;
    }
}
