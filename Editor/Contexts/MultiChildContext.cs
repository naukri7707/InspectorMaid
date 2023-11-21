using System;
using System.Collections.Generic;

namespace Naukri.InspectorMaid.Editor.Contexts
{
    public sealed class MultiChildContext : Context
    {
        public MultiChildContext(Widget widget) : base(widget)
        {
        }

        private readonly List<Context> children = new();

        public override void VisitChildContexts(Action<Context> visitor)
        {
            // copy children to avoid concurrent modification
            var childContexts = children.ToArray();
            foreach (var child in childContexts)
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
