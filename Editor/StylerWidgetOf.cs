using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Widgets;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class StylerWidgetOf<TAttribute> : StylerWidget, IAttributeProvider, IStylerWidgetProvider
        where TAttribute : StylerAttribute
    {
        private TAttribute _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public TAttribute attribute => _attribute;

        object IAttributeProvider.Attribute => attribute;

        Type IStylerWidgetProvider.RegisterType => typeof(TAttribute);

        StylerWidget IStylerWidgetProvider.CloneWith(object attribute)
        {
            var cloned = (StylerWidgetOf<TAttribute>)MemberwiseClone();

            cloned._attribute = attribute switch
            {
                TAttribute tAttribute => tAttribute,
                _ => throw new Exception($"{nameof(StylerWidgetOf<TAttribute>.attribute)} type mismatch."),
            };

            return cloned;
        }

        protected override void OnElementRendered(VisualElement renderedElement)
        {
            foreach (var className in attribute.classList)
            {
                renderedElement.AddToClassList(className);
            }
            OnStyling(renderedElement.style);
        }
    }
}
