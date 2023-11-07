using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    internal static class StylerWidgetTemplates
    {
        private static Dictionary<Type, IStylerWidgetProvider> _templates;

        internal static StylerWidget Create<T>(T attribute)
        {
            var template = GetTemplate(attribute.GetType());
            var inst = template.CloneWith(attribute);
            return inst;
        }

        private static IStylerWidgetProvider GetTemplate(Type type)
        {
            if (_templates == null)
                InitDict();
            return _templates[type];
        }

        private static void InitDict()
        {
            _templates = new Dictionary<Type, IStylerWidgetProvider>();

            var widgetTypes = TypeCache
                .GetTypesDerivedFrom(typeof(IStylerWidgetProvider))
                .Where(it => !it.IsAbstract)
                .ToList();

            foreach (var type in widgetTypes)
            {
                var inst = (IStylerWidgetProvider)Activator.CreateInstance(type);
                _templates[inst.RegisterType] = inst;
            }
        }
    }
}
