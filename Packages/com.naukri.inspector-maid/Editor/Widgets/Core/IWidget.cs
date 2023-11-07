using Naukri.InspectorMaid.Editor.Contexts.Core;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public interface IWidget
    {
        public Context CreateContext();
    }
}
