using Naukri.InspectorMaid.Core;
using UnityEngine.UIElements;
using IBindable = Naukri.InspectorMaid.Core.IBindable;

namespace Naukri.InspectorMaid
{
    public class HelpBoxAttribute : ItemAttribute, IBindable
    {
        public HelpBoxAttribute(
            string message = "",
            HelpBoxMessageType messageType = HelpBoxMessageType.None,
            string binding = null,
            params object[] args
            )
        {
            this.message = message;
            this.messageType = messageType;
            this.binding = binding;
            this.args = args;
        }

        public readonly string message;

        public readonly HelpBoxMessageType messageType;

        public object[] args { get; }

        public string binding { get; }
    }
}
