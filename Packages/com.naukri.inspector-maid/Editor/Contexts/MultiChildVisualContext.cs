using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;
using System.Collections.Generic;

namespace Naukri.InspectorMaid.Editor.Contexts
{
    public sealed class MultiChildVisualContext : VisualContext
    {
        public MultiChildVisualContext(VisualWidget widget) : base(widget) { }

        private readonly List<Context> children = new();

        public override void VisitChildContexts(Action<Context> visitor)
        {
            MultiChildContext.VisitChildContextsImpl(children, visitor);
        }

        protected override void OnChildAttached(Context child)
        {
            MultiChildContext.OnChildAttachedImpl(children, child);
        }
    }
}
