using Naukri.InspectorMaid.Editor.Receivers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class HideWidget : VisualWidgetOf<HideAttribute>, ITargetCreatedReceiver
    {
        public override VisualElement Build(IBuildContext context)
        {
            return null;
        }

        public void OnTargetCreated(IBuildContext context, VisualElement targetElement)
        {
            targetElement.style.display = DisplayStyle.None;
            targetElement.style.visibility = Visibility.Hidden;
        }
    }
}
