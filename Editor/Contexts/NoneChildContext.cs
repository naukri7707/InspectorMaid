using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;

namespace Naukri.InspectorMaid.Editor.Contexts
{
    public partial class NoneChildContext : Context
    {
        public NoneChildContext(IWidget widget)
        {
            Widget = widget;
        }

        public override IWidget Widget { get; }

        public override void VisitChildContexts(Action<Context> visitor)
        {
            VisitChildContextsImpl(visitor);
        }

        protected override void OnChildAttached(Context child)
        {
            OnChildAttachedImpl(child);
        }
    }

    partial class NoneChildContext
    {
        internal static void VisitChildContextsImpl(Action<Context> visitor)
        {
            // Do nothing. Because sometime we doesn't know if this context is NoneChildVisualContext or not.
        }

        internal static void OnChildAttachedImpl(Context child)
        {
            throw new InvalidOperationException($"{nameof(NoneChildContext)} is not support child context.");
        }
    }
}
