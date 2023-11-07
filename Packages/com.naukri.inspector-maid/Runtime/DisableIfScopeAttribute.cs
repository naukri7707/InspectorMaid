using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class DisableIfScopeAttribute : WidgetAttribute, IBindingDataProvider
    {
        public DisableIfScopeAttribute(
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
