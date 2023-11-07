using System;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    internal interface IStylerWidgetProvider
    {
        public Type RegisterType { get; }

        public StylerWidget CloneWith(object attribute);
    }
}
