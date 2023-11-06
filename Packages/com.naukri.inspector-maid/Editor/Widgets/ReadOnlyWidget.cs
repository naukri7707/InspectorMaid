using Naukri.InspectorMaid.Editor.Receivers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class ReadOnlyWidget : WidgetOf<ReadOnlyAttribute>, ITargetCreatedReceiver
    {
        public override VisualElement Build(IBuildContext context)
        {
            return null;
        }

        public void OnTargetCreated(IBuildContext context, VisualElement targetElement)
        {
            targetElement.SetEnabled(false);
        }
    }
}
