﻿using Naukri.InspectorMaid.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Core
{
    public static class WidgetBuilder
    {
        private static Dictionary<Type, IWidgetProvider> _templates;

        public static Widget Create(WidgetAttribute attribute)
        {
            var template = GetTemplate(attribute.GetType());
            var inst = template.CloneWith(attribute);
            return inst;
        }

        private static IWidgetProvider GetTemplate(Type type)
        {
            if (_templates == null)
            {
                InitDict();
            }

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
