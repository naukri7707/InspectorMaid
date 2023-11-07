using System;
using System.Collections.Generic;
using System.Linq;

namespace Naukri.InspectorMaid.Editor.Contexts.Core
{
    public abstract class MultiChildContext : Context
    {
        protected readonly List<Context> children = new();

        public sealed override void VisitChildContexts(Action<Context> visitor)
        {
            // copy children to avoid concurrent modification
            var childContexts = children.ToArray();
            foreach (var child in childContexts)
            {
                visitor(child);
            }
        }

        public sealed override void VisitChildVisualContexts(Action<VisualContext> visitor)
        {
            // copy children to avoid concurrent modification
            var childVisualContext = children.OfType<VisualContext>().ToArray();
            foreach (var child in childVisualContext)
            {
                visitor(child);
            }
        }

        protected override void OnChildAttached(Context child)
        {
            if (children.Contains(child))
            {
                throw new Exception($"{nameof(MultiChildContext)} contains this child already.");
            }

            children.Add(child);
        }
    }
}
