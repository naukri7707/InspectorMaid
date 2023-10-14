using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.UIElements
{
    public sealed class RangedIntegerField : IntegerField
    {
        public RangedIntegerField(int min, int max) : this(null, min, max) { }

        public RangedIntegerField(string label, int min, int max) : base(label, -1)
        {
            this.min = min;
            this.max = max;
        }

        private readonly int max;

        private readonly int min;

        public override int value
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
