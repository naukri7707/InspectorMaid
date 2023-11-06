using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Core
{
    internal static class StylerTemplates
    {
        private static Dictionary<Type, IStylerProvider> _templates;

        internal static Styler Create<T>(T model)
        {
            var template = GetTemplate(model.GetType());
            var inst = template.CloneWith(model);
            return inst;
        }

        private static IStylerProvider GetTemplate(Type type)
        {
            if (_templates == null)
            {
                InitDict();
            }
            return _templates[type];
        }

        private static void InitDict()
        {
            _templates = new Dictionary<Type, IStylerProvider>();

            var widgetTypes = TypeCache
                .GetTypesDerivedFrom(typeof(IStylerProvider))
                .Where(it => !it.IsAbstract)
                .ToList();

            foreach (var type in widgetTypes)
            {
                var inst = (IStylerProvider)Activator.CreateInstance(type);
                _templates[inst.RegisterType] = inst;
            }
        }
    }
}
