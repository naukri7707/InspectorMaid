using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;

namespace Naukri.InspectorMaid.Editor.Contexts
{
    public sealed partial class SingleChildContext : Context
    {
        public SingleChildContext(IWidget widget)
        {
            Widget = widget;
        }

        private Context child;

        public override IWidget Widget { get; }

        public override void VisitChildContexts(Action<Context> visitor)
        {
            VisitChildContexts(ref child, visitor);
        }

        protected override void OnChildAttached(Context child)
        {
            OnChildAttached(ref this.child, child);
        }
    }

    partial class SingleChildContext
    {
        internal static void VisitChildContexts(ref Context childRef, Action<Context> visitor)
        {
            visitor(childRef);
        }

        internal static void OnChildAttached(ref Context childRef, Context child)
        {
            if (childRef != null)
            {
                throw new Exception($"{nameof(SingleChildContext)} can only have one child");
            }

            childRef = child;
        }
    }
}
