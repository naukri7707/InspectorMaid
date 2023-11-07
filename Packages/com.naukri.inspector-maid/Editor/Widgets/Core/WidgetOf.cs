using Naukri.InspectorMaid.Editor.Contexts.Core;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public abstract class WidgetOf<TContext> : IWidget
        where TContext : Context
    {
        public abstract TContext CreateContext();

        void IWidget.OnContextAttached(Context context) => OnContextAttached((TContext)context);

        internal virtual void OnContextAttached(TContext context) { }
    }
}
