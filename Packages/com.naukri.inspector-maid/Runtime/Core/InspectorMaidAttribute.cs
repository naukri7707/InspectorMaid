using System;
using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Core
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class InspectorMaidAttribute : Attribute
    {
        [SuppressMessage("Style", "IDE1006")]
        public int order { get; set; }
    }
}
