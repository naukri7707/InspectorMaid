using Naukri.InspectorMaid.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid
{
    public class HelpBoxAttribute : BindableDrawerAttribute
    {
        public HelpBoxAttribute(
            string message = "",
            HelpBoxMessageType messageType = HelpBoxMessageType.None,
            FlexDirection flexDirection = FlexDirection.ColumnReverse,
            string binding = null,
            params object[] args
            ) : base(binding, args)
        {
            this.message = message;
            this.messageType = messageType;
            this.flexDirection = flexDirection;
        }

        public readonly string message;

        public readonly HelpBoxMessageType messageType;

        public readonly FlexDirection flexDirection;
    }
}
