using Naukri.InspectorMaid.Editor.Core;
using System;

namespace Naukri.InspectorMaid.Editor
{
    internal interface IStylerProvider
    {
        public Type RegisterType { get; }

        public Styler CloneWith(object model);
    }
}
