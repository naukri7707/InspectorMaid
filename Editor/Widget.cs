using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class Widget
    {
        public abstract VisualElement Build(IBuildContext context);

        public virtual Element CreateElementTree(Element parent)
        {
            return new Element(this, parent);
        }
    }
}
