using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public class DisableIfWidget : IfStylerWidgetOf<DisableIfAttribute>
    {
        public override string ClassName => "disable-if-styler";

        protected override VisualElement CreateContainer() => new DisableIf();

        protected override void OnUpdateElement(VisualElement element, bool condition)
        {
            element.SetEnabled(!condition);
        }

        private class DisableIf : VisualElement { }
    }
}
