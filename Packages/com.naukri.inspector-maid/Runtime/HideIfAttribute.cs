using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class HideIfAttribute : BindableDrawerAttribute
    {
        public HideIfAttribute(
            string binding = null,
            params object[] args
            ) : base(binding, args)
        {
        }
    }
}
