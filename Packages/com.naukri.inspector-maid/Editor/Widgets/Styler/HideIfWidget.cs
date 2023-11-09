using Naukri.InspectorMaid.Editor.Extensions;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public class HideIfWidget : IfStylerWidgetOf<HideIfAttribute>
    {
        public override string ClassName => "hide-if-styler";

        protected override VisualElement CreateContainer() => new HideIf();

        protected override void OnUpdateElement(VisualElement element, bool condition)
        {
            element.SetDisplay(!condition);
        }

        private class HideIf : VisualElement { }
    }
}
