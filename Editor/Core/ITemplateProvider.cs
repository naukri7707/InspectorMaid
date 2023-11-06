using System;

namespace Naukri.InspectorMaid.Editor
{
    internal interface IWidgetProvider
    {
        public Type RegisterType { get; }

        public Widget CloneWith(object model);
    }
}
