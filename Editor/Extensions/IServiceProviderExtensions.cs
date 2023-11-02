using System;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class IServiceProviderExtensions
    {
        public static T GetService<T>(this IServiceProvider self)
        {
            return (T)self.GetService(typeof(T));
        }
    }
}
