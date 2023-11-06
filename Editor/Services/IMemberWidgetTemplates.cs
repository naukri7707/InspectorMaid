using Naukri.InspectorMaid.Editor.Widgets;

namespace Naukri.InspectorMaid.Editor.Services
{
    internal partial interface IMemberWidgetTemplates
    {
        public void Add(MemberWidget memberWidget);

        public void Add(string key, MemberWidget memberWidget);

        public MemberWidget Create(string key);

        public void Remove(string key);
    }

    partial interface IMemberWidgetTemplates
    {
        public static IMemberWidgetTemplates Of(IBuildContext context)
        {
            return context.GetService<IMemberWidgetTemplates>();
        }
    }
}
