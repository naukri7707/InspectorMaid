using System;

namespace Naukri.InspectorMaid.Editor.Contexts.Core
{
    public abstract class SingleChildContext : Context
    {
        protected Context child;

        public override void VisitChildContexts(Action<Context> visitor)
        {
            visitor(child);
        }

        public override void VisitChildVisualContexts(Action<VisualContext> visitor)
        {
            if (child is VisualContext visualContext)
                visitor(visualContext);
        }

        protected override void OnChildAttached(Context child)
        {
            if (this.child != null)
            {
                throw new Exception($"{nameof(Core.SingleChildContext)} can only have one child");
            }

            this.child = child;
        }
    }
}
