using Naukri.InspectorMaid.Editor.Contexts.Core;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public abstract class Widget : IWidget
    {
        public abstract Context CreateContext();
    }
}
