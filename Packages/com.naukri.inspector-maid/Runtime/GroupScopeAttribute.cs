using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class GroupScopeAttribute : ScopeAttribute
    {
        public GroupScopeAttribute(
            string text = null,
            bool expend = false
            )
        {
            this.text = text;
            this.expend = expend;
        }

        public readonly string text;

        public readonly bool expend;
    }
}
