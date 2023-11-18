using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using System;
using System.Linq;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public abstract class IfScopeWidgetOf<TAttribute> : ScopeWidgetOf<TAttribute>
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

            var container = CreateContainer().Compose(c =>
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

        protected abstract VisualElement CreateContainer();

        protected abstract void OnUpdateElement(VisualElement container, bool condition);

        private void UpdateElement(VisualElement container, object bindingValue)
        {
            var condition = Condition(bindingValue);
            OnUpdateElement(container, condition);
        }

        private bool IsEqual(object lhs, object rhs)
        {
            // Because Unity override '==' operator for UObject.
            // So if any of them is UObject, compare them by '==' operator.
            if (lhs is UObject || rhs is UObject)
            {
                var uLhs = lhs as UObject;
                var uRhs = rhs as UObject;
                return uLhs == uRhs;
            }
            // Compare them in other case.
            else
            {
                // Cause of the boxing, we can't use '==' operator, otherwise it will compare them by reference.
                // e.g.
                // object a = 1;
                // object b = 1;
                // bool c = a == b; // c is false
                return Equals(lhs, rhs);
            }
        }

        private bool Condition(object bindingValue)
        {
            var res = false;

            if (attribute.conditionLogic == ConditionLogic.Value)
            {
                res = attribute.values.Length switch
                {
                    // return true if value isn't default.
                    0 => !IsEqual(bindingValue, bindingMemberDefaultValue),
                    _ => attribute.values.Any(it => IsEqual(bindingValue, it)),
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
