using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class IBindingDataProviderExtensions
    {
        // we have to use extension method, instead of default interface property.
        // so that we can use this method on the implementation of this interface without casting.
        public static bool IsBinding(this IBindingDataProvider self)
        {
            return self.binding != null;
        }
    }
}
