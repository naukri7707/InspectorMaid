using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class DisableIfAttribute : BindableDrawerAttribute
    {
        public DisableIfAttribute(
            string binding = null,
            params object[] args
            ) : base(binding, args)
        {
        }
    }
}
