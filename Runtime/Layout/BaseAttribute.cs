using Naukri.InspectorMaid.Core;
using System;

namespace Naukri.InspectorMaid.Layout
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class BaseAttribute : ItemAttribute, IDeclaredTypeProvider
    {
        public BaseAttribute()
        {
        }

        Type IDeclaredTypeProvider.DeclaredType { get; set; }
    }
}
