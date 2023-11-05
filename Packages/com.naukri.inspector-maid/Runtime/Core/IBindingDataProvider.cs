using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Core
{
    public interface IBindingDataProvider
    {
        [SuppressMessage("Style", "IDE1006")]
        public string binding { get; }

        [SuppressMessage("Style", "IDE1006")]
        public object[] args { get; }
    }
}
