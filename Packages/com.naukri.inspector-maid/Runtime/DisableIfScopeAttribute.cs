﻿using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class DisableIfScopeAttribute : IfScopeAttribute
    {
        public DisableIfScopeAttribute(string binding, object[] args = null) : base(binding, args)
        {
        }

        public DisableIfScopeAttribute(string binding, object value, ConditionLogic conditionLogic = ConditionLogic.Value, object[] args = null) : base(binding, value, conditionLogic, args)
        {
        }

        public DisableIfScopeAttribute(string binding, object value1, object value2, ConditionLogic conditionLogic = ConditionLogic.Value, object[] args = null) : base(binding, value1, value2, conditionLogic, args)
        {
        }

        public DisableIfScopeAttribute(string binding, object value1, object value2, object value3, ConditionLogic conditionLogic = ConditionLogic.Value, object[] args = null) : base(binding, value1, value2, value3, conditionLogic, args)
        {
        }

        public DisableIfScopeAttribute(string binding, object value1, object value2, object value3, object value4, ConditionLogic conditionLogic = ConditionLogic.Value, object[] args = null) : base(binding, value1, value2, value3, value4, conditionLogic, args)
        {
        }

        public DisableIfScopeAttribute(string binding, object[] values, ConditionLogic conditionLogic = ConditionLogic.Value, object[] args = null) : base(binding, values, conditionLogic, args)
        {
        }
    }
}
