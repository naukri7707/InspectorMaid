using System;

namespace Naukri.InspectorMaid.Core
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class InspectorMaidAttribute : Attribute
    {
        public object[] args;

        public string binding;

        public int order { get; set; }
    }
}
