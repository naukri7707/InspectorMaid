using Naukri.InspectorMaid.Core;
using System;

namespace Naukri.InspectorMaid
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class TemplateAttribute : LogicAttribute
    {
    }
}
