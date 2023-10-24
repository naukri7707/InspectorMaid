using Naukri.InspectorMaid.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid
{
    public class ButtonAttribute : BindableDrawerAttribute
    {
        public ButtonAttribute(
            string text = "",
            string binding = null,
            params object[] args
            ) : base(binding, args)
        {
            this.text = text;
        }

        public readonly string text;
    }
}
