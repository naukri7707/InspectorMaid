using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class EnableIfScopeAttribute : WidgetAttribute, IBindingDataProvider
    {
        public EnableIfScopeAttribute(
            string binding = null,
            params object[] args
            )
        {
            this.binding = binding;
            this.args = args;
        }

        public object[] args { get; }

        public string binding { get; }
    }
}
