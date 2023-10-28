using System;

namespace Naukri.InspectorMaid.Core
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class DecoratorAttribute : Attribute
    { }
}
