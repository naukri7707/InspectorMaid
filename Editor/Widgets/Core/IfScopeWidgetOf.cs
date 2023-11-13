using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using System;
using System.Linq;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public abstract class IfScopeWidgetOf<TAttribute> : ScopeWidgetOf<TAttribute>
         where TAttribute : IfScopeAttribute
    {
        public sealed override VisualElement Build(IBuildContext context)
        {
            var container = new VisualElement().Compose(c =>
            {
                c.children = BuildChildren(context);
            });

            var bindingValue = context.GetBindingValue();
            UpdateElement(container, bindingValue);

            if (attribute.IsBinding())
            {
                context.ListenBindingValue(v =>
                {
                    UpdateElement(container, v);
                });
            }

            return container;
        }

        protected abstract void OnUpdateElement(VisualElement visualElement, bool condition);

        private void UpdateElement(VisualElement visualElement, object bindingValue)
        {
            var condition = Condition(bindingValue);
            OnUpdateElement(visualElement, condition);
        }

        private bool Condition(object bindingValue)
        {
            var res = false;

            if (attribute.conditionLogic == ConditionLogic.Value)
            {
                res = attribute.values.Length switch
                {
                    0 => (bool)bindingValue,
                    _ => attribute.values.Any(it => bindingValue.Equals(it)),
                };
            }
            else if (attribute.conditionLogic == ConditionLogic.Flag)
            {
                res = bindingValue switch
                {
                    Enum enumValue => attribute.values.Cast<Enum>().Any(flag => enumValue.HasFlag(flag)),
                    _ => throw new Exception($"The binding value is not Enum. {bindingValue}"),
                };
            }

            return res;
        }
    }
}
