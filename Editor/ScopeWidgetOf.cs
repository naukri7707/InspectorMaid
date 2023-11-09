using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class LogicWidgetOf<TAttribute> : LogicWidget, IWidgetProvider
        where TAttribute : LogicAttribute
    {
        private TAttribute _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public TAttribute attribute => _attribute;

        object IAttributeProvider.Attribute => _attribute;

        Type IWidgetProvider.RegisterType => typeof(TAttribute);

        IWidget IWidgetProvider.CloneWith(WidgetAttribute attribute)
        {
            var cloned = (LogicWidgetOf<TAttribute>)MemberwiseClone();

            cloned._attribute = attribute switch
            {
                TAttribute tAttribute => tAttribute,
                _ => throw new Exception($"attribute type mismatch."),
            };

            return cloned;
        }
    }

    public abstract class ScopeWidgetOf<TAttribute> : ScopeWidget, IWidgetProvider
        where TAttribute : ScopeAttribute
    {
        private TAttribute _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public TAttribute attribute => _attribute;

        object IAttributeProvider.Attribute => _attribute;

        Type IWidgetProvider.RegisterType => typeof(TAttribute);

        IWidget IWidgetProvider.CloneWith(WidgetAttribute attribute)
        {
            var cloned = (ScopeWidgetOf<TAttribute>)MemberwiseClone();

            cloned._attribute = attribute switch
            {
                TAttribute tAttribute => tAttribute,
                _ => throw new Exception($"attribute type mismatch."),
            };

            return cloned;
        }
    }
}
