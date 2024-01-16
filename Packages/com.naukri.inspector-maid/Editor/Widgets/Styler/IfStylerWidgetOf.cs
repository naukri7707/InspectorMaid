using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Services;
using System;
using System.Linq;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Stylers
{
    public abstract class IfStylerWidgetOf<TAttribute> : StylerWidgetOf<TAttribute>
        where TAttribute : IfStylerAttribute
    {
        private object bindingMemberDefaultValue;

        public override void OnStyling(IBuildContext context, VisualElement element)
        {
            // Cache the default value for the performance.
            var bindingValueType = context.GetBindingValueType();
            bindingMemberDefaultValue = bindingValueType.IsValueType switch
            {
                true => Activator.CreateInstance(bindingValueType),
                false => null,
            };

            var bindingValue = context.GetBindingValue();
            UpdateElement(element, bindingValue);

            if (attribute.IsBinding())
            {
                context.ListenBindingValue(v =>
                {
                    UpdateElement(element, v);
                });
            }
        }

        protected abstract VisualElement CreateContainer();

        protected abstract void OnUpdateElement(VisualElement element, bool condition);

        private void UpdateElement(VisualElement element, object bindingValue)
        {
            var condition = Condition(bindingValue);
            OnUpdateElement(element, condition);
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
                    // return true if value is equal to any value in target values.
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
