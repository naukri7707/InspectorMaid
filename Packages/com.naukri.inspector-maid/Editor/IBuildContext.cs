using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Widgets;
using System;

namespace Naukri.InspectorMaid.Editor
{
    public interface IBuildContext
    {
        public Widget Widget { get; }

        public T GetAncestorWidget<T>() where T : Widget;

        public Element GetElementOfAncestorWidget<T>() where T : Widget;

        public void VisitAncestorElements(Predicate<Element> visitor);

        public void VisitChildElements(Action<Element> visitor);

        public T GetService<T>()
        {
            var provider = GetAncestorWidget<ServiceWidget>();
            return provider.GetService<T>();
        }
    }

    internal static class IBuildContextExtension
    {
        public static Element AsElement(this IBuildContext context)
        {
            return context as Element;
        }

        public static T GetModel<T>(this IBuildContext context)
        {
            if (context.Widget is IModelProvider modelProvider)
            {
                if (modelProvider.Model is T tModel)
                {
                    return tModel;
                }
                else
                {
                    throw new Exception($"{nameof(IModelProvider.Model)} type mismatch.");
                }
            }
            else
            {
                throw new Exception($"{nameof(IBuildContext.Widget)} is not {nameof(IModelProvider)}.");
            }
        }
    }
}
