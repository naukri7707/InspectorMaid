using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Core
{
    public interface IClassableProvider
    {
        [SuppressMessage("Style", "IDE1006")]
        public string[] classList { get; }
    }
}
