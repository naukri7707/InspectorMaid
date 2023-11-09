using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public class EnableIfWidget : IfStylerWidgetOf<EnableIfAttribute>
    {
        public override string ClassName => "enable-if-styler";

        protected override VisualElement CreateContainer() => new EnableIf();

        protected override void OnUpdateElement(VisualElement element, bool condition)
        {
            element.SetEnabled(condition);
        }

        private class EnableIf : VisualElement { }
    }
}
