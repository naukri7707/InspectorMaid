using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
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

        public void Attach(Context child)
        {
            if (child == null)
            {
                throw new ArgumentNullException(nameof(child));
            }

            child._parent = this;
            OnChildAttached(child);

            child.VisitReceiver<IContextAttachedReceiver>((ctx, r) => r.OnContextAttached(ctx));
        }

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

        protected abstract void OnChildAttached(Context child);
    }
}
