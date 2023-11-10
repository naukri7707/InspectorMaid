using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class ColumnScopeAttribute : ScopeAttribute
    {
        public ColumnScopeAttribute(bool reverse = false)
        {
            this.reverse = reverse;
        }

        public readonly bool reverse;
    }
}
