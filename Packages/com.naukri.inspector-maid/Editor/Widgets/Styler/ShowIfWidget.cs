using Naukri.InspectorMaid.Editor.Extensions;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public class ShowIfWidget : IfStylerWidgetOf<ShowIfAttribute>
    {
        public override string ClassName => "show-if-styler";

        protected override VisualElement CreateContainer() => new ShowIf();

        protected override void OnUpdateElement(VisualElement element, bool condition)
        {
            element.AddToClassList("show-if");
            element.SetDisplay(condition);
        }

        private class ShowIf : VisualElement { }
    }
}
