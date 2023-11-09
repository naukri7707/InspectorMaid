using Naukri.InspectorMaid.Core;
using System;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    internal interface IWidgetProvider : IAttributeProvider
    {
        public Type RegisterType { get; }

        public IWidget CloneWith(WidgetAttribute attribute);
    }
}
