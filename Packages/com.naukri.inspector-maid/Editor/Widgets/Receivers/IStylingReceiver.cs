using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Receivers
{
    internal interface IStylingReceiver : IReceiver
    {
        void OnStyling(IBuildContext context, VisualElement stylingElement);
    }
}
