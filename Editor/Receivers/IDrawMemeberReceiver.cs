using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Receivers
{
    public interface IDrawMemeberReceiver : IReceiver
    {
        public void OnDrawMember(IWidget widget, VisualElement memberElement);
    }
}
