using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class EnableIfAttribute : BindableDrawerAttribute
    {
        public EnableIfAttribute(
            string binding = null,
            params object[] args
            ) : base(binding, args)
        {
        }
    }
}
