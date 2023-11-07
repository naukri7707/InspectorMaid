using Naukri.InspectorMaid.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    internal static class WidgetTemplates
    {
        private static Dictionary<Type, IWidgetProvider> _templates;

        internal static IWidget Create<T>(T attribute) where T : WidgetAttribute
        {
            var template = GetTemplate(attribute.GetType());
            var inst = template.CloneWith(attribute);
            return inst;
        }

        private static IWidgetProvider GetTemplate(Type type)
        {
            if (_templates == null)
                InitDict();
            return _templates[type];
        }

        private static void InitDict()
        {
            _templates = new Dictionary<Type, IWidgetProvider>();

            var widgetTypes = TypeCache
                .GetTypesDerivedFrom(typeof(IWidgetProvider))
                .Where(it => !it.IsAbstract)
                .ToList();

            foreach (var type in widgetTypes)
            {
                var inst = (IWidgetProvider)Activator.CreateInstance(type);
                _templates[inst.RegisterType] = inst;
            }
        }
    }
}
