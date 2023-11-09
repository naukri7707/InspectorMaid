using Naukri.InspectorMaid.Core;
using System;

namespace Naukri.InspectorMaid.Layout
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class MembersAttribute : ItemAttribute, IDeclaredTypeProvider
    {
        public MembersAttribute(bool skipTemplate = true)
        {
            this.skipTemplate = skipTemplate;
        }

        public readonly bool skipTemplate;

        Type IDeclaredTypeProvider.DeclaredType { get; set; }
    }
}
