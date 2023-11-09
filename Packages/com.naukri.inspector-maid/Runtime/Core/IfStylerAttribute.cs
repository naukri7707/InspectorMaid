namespace Naukri.InspectorMaid.Core
{
    public abstract class IfStylerAttribute : StylerAttribute, IBindingDataProvider
    {
        // We avoid using object[] to set values because its precedence is higher than object.
        // This could lead to misinterpretation when using null as a value, as it would be treated as an object[].
        // For instance,
        // ShowIf("field", null): We expect the field to be displayed when it is null.
        // However, due to the mentioned reason, it is treated as an empty object[], equivalent to ShowIf("field"),
        // so the field won't be displayed, but this is obviously a logical error.
        // Therefore, we refrain from using object[] to define values and instead use multiple value parameters to define values, preventing this issue.
        protected IfStylerAttribute(
            string binding,
            object[] values,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            )
        {
            this.binding = binding;
            this.values = values;
            this.conditionLogic = conditionLogic;
            this.args = args;
        }

        public readonly object[] values;

        public readonly ConditionLogic conditionLogic;

        public string binding { get; }

        public object[] args { get; }
    }
}
