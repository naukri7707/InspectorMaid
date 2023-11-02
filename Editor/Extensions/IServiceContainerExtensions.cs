using System.ComponentModel.Design;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class IServiceContainerExtensions
    {
        public static void AddService<T>(this IServiceContainer self, bool promote = false) where T : new()
        {
            var serviceInstance = new T();
            self.AddService(typeof(T), serviceInstance, promote);
        }

        public static void AddService<T>(this IServiceContainer self, T serviceInstance, bool promote = false)
        {
            self.AddService(typeof(T), serviceInstance, promote);
        }

        public static void AddService<T>(this IServiceContainer self, ServiceCreatorCallback callback, bool promote = false)
        {
            self.AddService(typeof(T), callback, promote);
        }

        public static void RemoveService<T>(this IServiceContainer self, bool promote = false)
        {
            self.RemoveService(typeof(T), promote);
        }
    }
}
