using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Receivers
{
    public interface ITargetBuildedReceiver
    {
        public void OnTargetBuilded(IBuildContext context, VisualElement targetElement);
    }
}
