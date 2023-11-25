using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
using static Naukri.InspectorMaid.Editor.IBuildContext;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class Context : IBuildContext
    {
        protected Context(Widget widget)
        {
            _widget = widget;
        }

        public VisualElement renderedElement;

        private readonly Widget _widget;

        private Context _parent;

        public Context Parent => _parent;

        public Widget Widget => _widget;

        public VisualElement[] BuildChildren(ChildBuiltCallback callback = null)
        {
            var children = new List<VisualElement>();
            VisitChildContexts(child =>
            {
                if (child is Context visualContext)
                {
                    var childElement = visualContext.Build();

                    if (childElement != null)
                    {
                        callback?.Invoke(child, childElement);
                        children.Add(childElement);
                    }
                }
            });

            return children.ToArray();
        }

        public T GetAncestorWidget<T>() where T : Widget
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

        public Context GetContextOfAncestorWidget<T>() where T : Widget
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

        internal VisualElement Build()
        {
            renderedElement = _widget.Build(this);

            this.VisitChildReceivers<IParentBuiltReceiver>((ctx, r) =>
            {
                r.OnParentBuilt(ctx, renderedElement);
            });

            return renderedElement;
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
