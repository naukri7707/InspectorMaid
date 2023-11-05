using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public class NoGUIImplemented<T> : BaseField<T>
    {
        public NoGUIImplemented() : this("")
        { }

        public NoGUIImplemented(string label) : base(label, new Label("No GUI Implemented"))
        { }
    }
}
