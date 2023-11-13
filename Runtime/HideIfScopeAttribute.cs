using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class HideIfScopeAttribute : IfScopeAttribute
    {
        public HideIfScopeAttribute(string binding, object[] args = null) : base(binding, args)
        {
        }

        public HideIfScopeAttribute(string binding, object value, ConditionLogic conditionLogic = ConditionLogic.Value, object[] args = null) : base(binding, value, conditionLogic, args)
        {
        }

        public HideIfScopeAttribute(string binding, object[] values, ConditionLogic conditionLogic = ConditionLogic.Value, object[] args = null) : base(binding, values, conditionLogic, args)
        {
        }

        public HideIfScopeAttribute(string binding, object value1, object value2, ConditionLogic conditionLogic = ConditionLogic.Value, object[] args = null) : base(binding, value1, value2, conditionLogic, args)
        {
        }

        public HideIfScopeAttribute(string binding, object value1, object value2, object value3, ConditionLogic conditionLogic = ConditionLogic.Value, object[] args = null) : base(binding, value1, value2, value3, conditionLogic, args)
        {
        }

        public HideIfScopeAttribute(string binding, object value1, object value2, object value3, object value4, ConditionLogic conditionLogic = ConditionLogic.Value, object[] args = null) : base(binding, value1, value2, value3, value4, conditionLogic, args)
        {
        }
    }
}
