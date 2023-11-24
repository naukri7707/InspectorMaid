using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using System;
using System.Linq;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public abstract class IfScopeWidgetOf<TAttribute> : VisualWidgetOf<TAttribute>
        where TAttribute : IfScopeAttribute
    {
        private object bindingMemberDefaultValue;

        public sealed override VisualElement Build(IBuildContext context)
        {
            // Cache the default value for the performance.
            var bindingValueType = context.GetBindingValueType();
            bindingMemberDefaultValue = bindingValueType.IsValueType switch
            {
                true => Activator.CreateInstance(bindingValueType),
                false => null,
            };

            var container = CreateContainer().Compose(ve =>
            {
                ve.children = context.BuildChildren();
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

        protected abstract VisualElement CreateContainer();

        protected abstract void OnUpdateElement(VisualElement container, bool condition);

        private void UpdateElement(VisualElement container, object bindingValue)
        {
            var condition = Condition(bindingValue);
            OnUpdateElement(container, condition);
        }

        private bool Condition(object bindingValue)
        {
            var res = false;

            if (attribute.conditionLogic == ConditionLogic.Value)
            {
                res = attribute.values.Length switch
                {
                    // return true if value isn't default.
                    0 => !InspectorMaidUtility.IsBoxedValueEqual(bindingValue, bindingMemberDefaultValue),
                    _ => attribute.values.Any(it => InspectorMaidUtility.IsBoxedValueEqual(bindingValue, it)),
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
