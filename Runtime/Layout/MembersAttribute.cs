using Naukri.InspectorMaid.Core;
using System;

namespace Naukri.InspectorMaid.Layout
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class MembersAttribute : ItemAttribute
    {
        public MembersAttribute(bool skipTemplate = true, bool skipScriptField = false)
        {
            this.skipTemplate = skipTemplate;
            this.skipScriptField = skipScriptField;
        }

        public readonly bool skipTemplate;

        public readonly bool skipScriptField;
    }
}
