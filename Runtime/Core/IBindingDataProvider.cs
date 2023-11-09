using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Core
{
    [SuppressMessage("Style", "IDE1006")]
    public interface IBindingDataProvider
    {
        public string binding { get; }

        public object[] args { get; }
    }
}
