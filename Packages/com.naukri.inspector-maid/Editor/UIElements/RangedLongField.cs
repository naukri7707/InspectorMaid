using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public sealed class RangedLongField : LongField
    {
        public RangedLongField(long min, long max) : this(null, min, max) { }

        public RangedLongField(string label, long min, long max) : base(label, -1)
        {
            this.min = min;
            this.max = max;
        }

        private readonly long max;

        private readonly long min;

        public override long value
        {
            get => base.value;
            set
            {
                if (value > max)
                {
                    value = max;
                }
                else if (value < min)
                {
                    value = min;
                }
                base.value = value;
            }
        }
    }
}
