using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class FoldoutScopeAttribute : ScopeAttribute
    {
        public FoldoutScopeAttribute(string text, bool expend = false)
        {
            this.text = text;
            this.expend = expend;
        }

        public readonly string text;

        public readonly bool expend;
    }
}
