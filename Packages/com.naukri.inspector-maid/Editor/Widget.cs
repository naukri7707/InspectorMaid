using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class Widget
    {
        public abstract Context CreateContext();

        public abstract VisualElement Build(IBuildContext context);
    }
}
