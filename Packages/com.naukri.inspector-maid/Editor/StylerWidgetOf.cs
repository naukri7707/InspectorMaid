using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class StylerWidgetOf<TAttribute> : WidgetOf<TAttribute>, IWidgetProvider, IParentBuiltReceiver
        where TAttribute : StylerAttribute
    {
        public abstract string ClassName { get; }

        public sealed override Context CreateContext() => new NoneChildContext(this);

        public sealed override VisualElement Build(IBuildContext context) => null;

        public abstract void OnStyling(IBuildContext context, VisualElement element);

        void IParentBuiltReceiver.OnParentBuilt(IBuildContext context, VisualElement parentElement)
        {
            parentElement.AddToClassList(ClassName);
            OnStyling(context, parentElement);
        }
    }
}
