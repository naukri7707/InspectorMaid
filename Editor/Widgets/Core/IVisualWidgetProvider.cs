using System;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    internal interface IVisualWidgetProvider
    {
        public Type RegisterType { get; }

        public VisualWidget CloneWith(object attribute);
    }
}
