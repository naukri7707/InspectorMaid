using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid
{
    public class HideIfAttribute : IfStylerAttribute
    {
        public HideIfAttribute(
            string binding,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            ) : base(
                  binding,
                  new object[0],
                  conditionLogic,
                  args
                  )
        {
        }

        public HideIfAttribute(
            string binding,
            object value,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            ) : base(
                  binding,
                  new object[] { value },
                  conditionLogic,
                  args
                  )
        {
        }

        public HideIfAttribute(
            string binding,
            object value1,
            object value2,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            ) : base(
                  binding,
                  new object[] { value1, value2 },
                  conditionLogic,
                  args
                  )
        {
        }

        public HideIfAttribute(
            string binding,
            object value1,
            object value2,
            object value3,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            ) : base(
                  binding,
                  new object[] { value1, value2, value3 },
                  conditionLogic,
                  args
                  )
        {
        }

        public HideIfAttribute(
            string binding,
            object value1,
            object value2,
            object value3,
            object value4,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            ) : base(
                  binding,
                  new object[] { value1, value2, value3, value4 },
                  conditionLogic,
                  args
                  )
        {
        }

        public HideIfAttribute(
            string binding,
            object value1,
            object value2,
            object value3,
            object value4,
            object value5,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            ) : base(
                  binding,
                  new object[] { value1, value2, value3, value4, value5 },
                  conditionLogic,
                  args
                  )
        {
        }

        public HideIfAttribute(
            string binding,
            object value1,
            object value2,
            object value3,
            object value4,
            object value5,
            object value6,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            ) : base(
                  binding,
                  new object[] { value1, value2, value3, value4, value5, value6 },
                  conditionLogic,
                  args
                  )
        {
        }

        public HideIfAttribute(
            string binding,
            object value1,
            object value2,
            object value3,
            object value4,
            object value5,
            object value6,
            object value7,
            ConditionLogic conditionLogic = ConditionLogic.Value,
            object[] args = null
            ) : base(
                  binding,
                  new object[] { value1, value2, value3, value4, value5, value6, value7 },
                  conditionLogic,
                  args
                  )
        {
        }
    }
}
