using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Widgets;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;

namespace Naukri.InspectorMaid.Editor
{
    public interface IBuildContext
    {
        public IWidget Widget { get; }

        public T GetAncestorWidget<T>() where T : IWidget;

        public Context GetContextOfAncestorWidget<T>() where T : IWidget;

        public void VisitAncestorContexts(Predicate<Context> visitor);

        public void VisitChildContexts(Action<Context> visitor);

        public void VisitChildVisualContexts(Action<VisualContext> visitor);

        public T GetService<T>()
        {
            var provider = GetAncestorWidget<ServiceWidget>();
            return provider.GetService<T>();
        }
    }
}
