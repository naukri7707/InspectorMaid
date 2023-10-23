using Naukri.InspectorMaid.Core;
using System;
using System.Collections.Generic;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Core
{
    internal static class StylerTemplates
    {
        private static Dictionary<Type, CustomStyler> _templates;

        private static Dictionary<Type, CustomStyler> Templates
        {
            get
            {
                if (_templates == null)
                {
                    _templates = new Dictionary<Type, CustomStyler>();
                    var drawerTypes = TypeCache.GetTypesDerivedFrom(typeof(CustomStylerOf<>));
                    foreach (var type in drawerTypes)
                    {
                        var inst = (CustomStyler)Activator.CreateInstance(type);
                        _templates[inst.AttributeType] = inst;
                    }
                }
                return _templates;
            }
        }

        internal static CustomStyler Create(StylerAttribute attribute)
        {
            var type = attribute.GetType();
            var template = Templates[type];
            var instance = template.CloneWith(attribute);
            return instance;
        }
    }
}
