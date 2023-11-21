using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class Widget
    {
        public abstract Context CreateContext();

        public abstract VisualElement Build(IBuildContext context);

        public VisualElement[] BuildChildren(IBuildContext context, ChildBuiltCallback callback = null)
        {
            var children = new List<VisualElement>();
            context.VisitChildContexts(child =>
            {
                if (child is Context visualContext)
                {
                    var childElement = visualContext.Build();

                    if (childElement != null)
                    {
                        callback?.Invoke(child, childElement);
                        children.Add(childElement);
                    }
                }
            });

            return children.ToArray();
        }

        public delegate void ChildBuiltCallback(Context ctx, VisualElement e);
    }
}
