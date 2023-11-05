using Naukri.InspectorMaid.Editor.Extensions;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Services
{
    public partial interface IInspectorMaidSettings
    {
        StyleSheet[] ImportStyleSheets { get; }
    }

    partial interface IInspectorMaidSettings
    {
        public static IInspectorMaidSettings Of(IBuildContext context)
        {
            return context.GetService<IInspectorMaidSettings>();
        }
    }
}
