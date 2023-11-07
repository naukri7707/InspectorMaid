using Naukri.InspectorMaid.Editor.Contexts.Core;

namespace Naukri.InspectorMaid.Editor.Receivers
{
    public interface IContextAttachedReceiver
    {
        public void OnContextAttached(Context context);
    }
}
