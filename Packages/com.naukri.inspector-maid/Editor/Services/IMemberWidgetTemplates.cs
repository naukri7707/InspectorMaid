using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Widgets.Visual;

namespace Naukri.InspectorMaid.Editor.Services
{
    internal partial interface IMemberWidgetTemplates
    {
        public void Register(MemberWidget memberWidget);

        public MemberWidget Create(string key);

        public void Deregister(string key);
    }

    partial interface IMemberWidgetTemplates
    {
        public static IMemberWidgetTemplates Of(IBuildContext context)
        {
            return context.GetService<IMemberWidgetTemplates>();
        }
    }
}
