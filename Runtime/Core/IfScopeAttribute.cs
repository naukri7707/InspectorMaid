namespace Naukri.InspectorMaid.Core
{
    public abstract class IfScopeAttribute : ScopeAttribute, IBindingDataProvider
    {
        public IfScopeAttribute(
            string binding,
            object value,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            ) : this(binding, new object[] { value }, conditionLogic, args)
        {
        }

        public IfScopeAttribute(
            string binding,
            object value1,
            object value2,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            ) : this(binding, new object[] { value1, value2 }, conditionLogic, args)
        {
        }

        public IfScopeAttribute(
            string binding,
            object value1,
            object value2,
            object value3,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            ) : this(binding, new object[] { value1, value2, value3 }, conditionLogic, args)
        {
        }

        public IfScopeAttribute(
            string binding,
            object value1,
            object value2,
            object value3,
            object value4,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            ) : this(binding, new object[] { value1, value2, value3, value4 }, conditionLogic, args)
        {
        }

        public IfScopeAttribute(
            string binding,
            object[] values = null,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            )
        {
            this.binding = binding;
            this.values = values ?? new object[0];
            this.conditionLogic = conditionLogic;
            this.args = args;
        }

        public readonly object[] values;

        public readonly ConditionLogic conditionLogic;

        public string binding { get; }

        public object[] args { get; }
    }
}
