using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;

namespace Naukri.InspectorMaid.Editor.Contexts
{
    public class NoneChildVisualContext : VisualContext
    {
        public NoneChildVisualContext(VisualWidget widget) : base(widget) { }

        public override void VisitChildContexts(Action<Context> visitor)
        {
            NoneChildContext.VisitChildContextsImpl(visitor);
        }

        protected override void OnChildAttached(Context child)
        {
            NoneChildContext.OnChildAttachedImpl(child);
        }
    }
}
