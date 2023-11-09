using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Widgets.Visual;
using System;
using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Services
{
    internal partial interface IMemberWidgetTemplates
    {
        public MemberWidget CreateMemberWidget(string memberName);

        public MemberWidget[] CreateMemberWidgets(Predicate<MemberInfo> filter = null);

        public MemberWidget[] CreateFieldWidgets();

        public MemberWidget[] CreatePropertyWidgets();

        public MemberWidget[] CreateMethodWidgets();
    }

    partial interface IMemberWidgetTemplates
    {
        public static IMemberWidgetTemplates Of(IBuildContext context)
        {
            return context.GetService<IMemberWidgetTemplates>();
        }
    }
}
