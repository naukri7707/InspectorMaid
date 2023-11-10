using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class RowScopeAttribute : ScopeAttribute
    {
        public RowScopeAttribute(bool reverse = false)
        {
            this.reverse = reverse;
        }

        public readonly bool reverse;
    }
}
