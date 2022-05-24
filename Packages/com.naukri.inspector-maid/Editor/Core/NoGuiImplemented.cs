using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public class NoGuiImplemented<T> : BaseField<T>
    {
        public NoGuiImplemented() : this("")
        { }

        public NoGuiImplemented(string label) : base(label, new Label("No GUI Implemented"))
        { }
    }
}
