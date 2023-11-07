using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;

namespace Naukri.InspectorMaid.Editor.Contexts
{
    public sealed class SingleChildVisualContext : VisualContext
    {
        public SingleChildVisualContext(VisualWidget widget) : base(widget) { }

        private Context child;

        public override void VisitChildContexts(Action<Context> visitor)
        {
            SingleChildContext.VisitChildContexts(ref child, visitor);
        }

        protected override void OnChildAttached(Context child)
        {
            SingleChildContext.OnChildAttached(ref this.child, child);
        }
    }
}
