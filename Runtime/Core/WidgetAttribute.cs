using System;

namespace Naukri.InspectorMaid.Core
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public abstract class WidgetAttribute : Attribute
    {
    }
}
