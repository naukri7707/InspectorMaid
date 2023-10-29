using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Events
{
    public class InspectorMaidEvent<T> : EventBase<T>
        where T : EventBase<T>, new()
    {
    }
}
