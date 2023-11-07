using Naukri.InspectorMaid.Editor.Widgets.Visual;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Services.Common
{
    internal class MemberWidgetTemplates : IMemberWidgetTemplates
    {
        private readonly Dictionary<string, MemberWidget> templates = new();

        public void Register(MemberWidget memberWidget)
        {
            templates.Add(memberWidget.info.Name, memberWidget);
        }

        public void Deregister(string key)
        {
            templates.Remove(key);
        }

        public MemberWidget Create(string key)
        {
            var template = templates[key];
            return new MemberWidget(template);
        }

        internal MemberWidget[] FieldWidgets()
        {
            return templates.Values
                .Where(it => it.info is FieldInfo)
                .Select(it => new MemberWidget(it))
                .ToArray();
        }

        internal MemberWidget[] PropertyWidgets()
        {
            return templates.Values
                .Where(it => it.info is PropertyInfo)
                .Select(it => new MemberWidget(it))
                .ToArray();
        }

        internal MemberWidget[] MethodWidgets()
        {
            return templates.Values
                .Where(it => it.info is MethodInfo)
                .Select(it => new MemberWidget(it))
                .ToArray();
        }
    }
}
