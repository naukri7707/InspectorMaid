using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Receivers
{
    public interface ITargetCreatedReceiver : IEventReceiver
    {
        public void OnTargetCreated(IBuildContext context, VisualElement targetElement);
    }
}
