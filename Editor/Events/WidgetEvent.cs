using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Events
{
    public interface IWidgetEvent
    {
    }

    public abstract class WidgetEvent<T> : EventBase<T>
            where T : EventBase<T>, new()
    {
    }
}
