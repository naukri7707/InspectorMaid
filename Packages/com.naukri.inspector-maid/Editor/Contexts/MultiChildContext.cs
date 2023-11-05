using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;
using System.Collections.Generic;

namespace Naukri.InspectorMaid.Editor.Contexts
{
    public sealed partial class MultiChildContext : Context
    {
        public MultiChildContext(IWidget widget)
        {
            Widget = widget;
        }

        private readonly List<Context> children = new();

        public override IWidget Widget { get; }

        public override void VisitChildContexts(Action<Context> visitor)
        {
            VisitChildContextsImpl(children, visitor);
        }

        protected override void OnChildAttached(Context child)
        {
            OnChildAttachedImpl(children, child);
        }
    }

    partial class MultiChildContext
    {
        internal static void VisitChildContextsImpl(List<Context> children, Action<Context> visitor)
        {
            // copy children to avoid concurrent modification
            var childContexts = children.ToArray();
            foreach (var child in childContexts)
            {
                visitor(child);
            }
        }

        internal static void OnChildAttachedImpl(List<Context> children, Context child)
        {
            if (children.Contains(child))
                throw new Exception($"{nameof(MultiChildContext)} contains this child already.");

            children.Add(child);
        }
    }
}
