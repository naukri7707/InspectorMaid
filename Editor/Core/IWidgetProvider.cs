using Naukri.InspectorMaid.Core;
using System;

namespace Naukri.InspectorMaid.Editor.Core
{
    internal interface IWidgetProvider : IAttributeProvider
    {
        public Type RegisterType { get; }

        public Widget CloneWith(WidgetAttribute attribute);
    }
}
