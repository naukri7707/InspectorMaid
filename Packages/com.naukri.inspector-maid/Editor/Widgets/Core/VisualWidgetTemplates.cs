using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    internal static class VisualWidgetTemplates
    {
        private static Dictionary<Type, IVisualWidgetProvider> _templates;

        internal static VisualWidget Create<T>(T attribute)
        {
            var template = GetTemplate(attribute.GetType());
            var inst = template.CloneWith(attribute);
            return inst;
        }

        private static IVisualWidgetProvider GetTemplate(Type type)
        {
            if (_templates == null)
                InitDict();
            return _templates[type];
        }

        private static void InitDict()
        {
            _templates = new Dictionary<Type, IVisualWidgetProvider>();

            var widgetTypes = TypeCache
                .GetTypesDerivedFrom(typeof(IVisualWidgetProvider))
                .Where(it => !it.IsAbstract)
                .ToList();

            foreach (var type in widgetTypes)
            {
                var inst = (IVisualWidgetProvider)Activator.CreateInstance(type);
                _templates[inst.RegisterType] = inst;
            }
        }
    }
}
