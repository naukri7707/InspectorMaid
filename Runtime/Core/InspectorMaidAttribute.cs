using System;
using UnityEngine;

namespace Naukri.InspectorMaid.Core
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class InspectorMaidAttribute : PropertyAttribute
    {
        public object[] args;

        public string binding;
    }
}
