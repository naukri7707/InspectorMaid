using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class FoldoutScopeAttribute : ScopeAttribute
    {
        public FoldoutScopeAttribute(string text)
        {
            this.text = text;
        }

        public readonly string text;
    }
}
