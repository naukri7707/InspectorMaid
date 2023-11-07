using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;

namespace Naukri.InspectorMaid.Editor.Contexts.Core
{
    public abstract class Context : IBuildContext
    {
        private Context _parent;

        public Context Parent => _parent;

        public abstract IWidget Widget { get; }

        public T GetAncestorWidget<T>() where T : IWidget
        {
            T res = default;

            VisitAncestorContexts(ctx =>
            {
                if (ctx.Widget is T tWidget)
                {
                    res = tWidget;
                    return true;
                }

                return false;
            });

            return res;
        }

        public Context GetContextOfAncestorWidget<T>() where T : IWidget
        {
            Context res = null;

            VisitAncestorContexts(e =>
            {
                if (e.Widget is T)
                {
                    res = e;
                    return true;
                }

                return false;
            });

            return res;
        }

        public void VisitAncestorContexts(Predicate<Context> visitor)
        {
            var current = this;
            while (current != null)
            {
                if (visitor.Invoke(current))
                    break;
                current = current.Parent;
            }
        }

        public abstract void VisitChildContexts(Action<Context> visitor);

        internal T GetAncestorContext<T>() where T : Context
        {
            T res = null;

            VisitAncestorContexts(ctx =>
            {
                if (ctx is T tCtx)
                {
                    res = tCtx;
                    return true;
                }

                return false;
            });

            return res;
        }

        internal void AttachParent(Context parent)
        {
            _parent = parent;
            _parent?.OnChildAttached(this);

            if (Widget is IContextAttachedReceiver reciver)
            {
                reciver.OnContextAttached(this);
            }
        }

        protected abstract void OnChildAttached(Context child);
    }
}
