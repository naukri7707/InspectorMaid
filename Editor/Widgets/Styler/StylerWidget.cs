using Naukri.InspectorMaid.Editor.Widgets.Core;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public abstract class StylerWidget : NoneChildWidget, IStylingReceiver
    {
        public abstract void OnStyling(IBuildContext context, VisualElement stylingElement);
    }
}
