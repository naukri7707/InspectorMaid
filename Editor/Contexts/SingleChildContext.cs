using System;

namespace Naukri.InspectorMaid.Editor.Contexts
{
    public sealed partial class SingleChildContext : Context
    {
        public SingleChildContext(Widget widget) : base(widget)
        {
        }

        private Context child;

        public override void VisitChildContexts(Action<Context> visitor)
        {
            visitor(child);
        }

        protected override void OnChildAttached(Context child)
        {
            if (this.child != null)
            {
                throw new Exception($"{nameof(SingleChildContext)} must have only one child.");
            }

            this.child = child;
        }
    }
}
