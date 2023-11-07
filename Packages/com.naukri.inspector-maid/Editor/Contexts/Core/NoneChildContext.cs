using System;

namespace Naukri.InspectorMaid.Editor.Contexts.Core
{
    public abstract class NoneChildContext : Context
    {
        public sealed override void VisitChildContexts(Action<Context> visitor) { }

        public sealed override void VisitChildVisualContexts(Action<VisualContext> visitor) { }

        protected sealed override void OnChildAttached(Context child) { }
    }
}
