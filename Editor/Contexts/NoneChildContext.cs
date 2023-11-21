using System;

namespace Naukri.InspectorMaid.Editor.Contexts
{
    public class NoneChildContext : Context
    {
        public NoneChildContext(Widget widget) : base(widget)
        {
        }

        public override void VisitChildContexts(Action<Context> visitor)
        {
            // Do nothing. Because sometime we doesn't know if this context is NoneChildVisualContext or not.
        }

        protected override void OnChildAttached(Context child)
        {
            throw new InvalidOperationException($"{nameof(NoneChildContext)} is not support child context.");
        }
    }
}
