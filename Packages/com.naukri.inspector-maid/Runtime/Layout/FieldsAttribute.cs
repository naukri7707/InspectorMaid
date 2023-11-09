using Naukri.InspectorMaid.Core;
using System;

namespace Naukri.InspectorMaid.Layout
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class FieldsAttribute : ItemAttribute, IDeclaredTypeProvider
    {
        public FieldsAttribute(bool skipTemplate = true)
        {
            this.skipTemplate = skipTemplate;
        }

        public readonly bool skipTemplate;

        Type IDeclaredTypeProvider.DeclaredType { get; set; }
    }
}
