using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Core
{
    public interface IUseClassable
    {
        [SuppressMessage("Style", "IDE1006")]
        public string[] classList { get; }
    }
}
