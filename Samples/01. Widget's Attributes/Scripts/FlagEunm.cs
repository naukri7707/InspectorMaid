using System;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    [Flags]
    public enum FlagEunm
    {
        A = 1 << 0,

        B = 1 << 1,

        C = 1 << 2,

        D = 1 << 3,

        E = 1 << 4,
    }
}
