using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class ShowIfAttribute : BindableDrawerAttribute
    {
        public ShowIfAttribute(
            string binding = null,
            params object[] args
            ) : base(binding, args)
        {
        }
    }
}
