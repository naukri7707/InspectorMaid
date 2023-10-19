using System;
using System.Collections.Generic;
using System.Reflection;
using Naukri.InspectorMaid.Core;
using UnityEditor;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    internal static class DrawerTemplates
    {
        private static Dictionary<Type, CustomDrawer> _templates;

        private static Dictionary<Type, CustomDrawer> Templates
        {
            get
            {
                if (_templates == null)
                {
                    _templates = new Dictionary<Type, CustomDrawer>();
                    var drawerTypes = TypeCache.GetTypesDerivedFrom(typeof(CustomDrawerOf<>));
                    foreach (var type in drawerTypes)
                    {
                        var inst = (CustomDrawer)Activator.CreateInstance(type);
                        _templates[inst.AttributeType] = inst;
                    }
                }
                return _templates;
            }
        }

        internal static CustomDrawer Create(Type type, InspectorMaidAttribute attribute, UObject target, MemberInfo info, SerializedProperty serializedProperty = null)
        {
            var template = Templates[type];
            var instance = template.CloneWith(attribute, target, info, serializedProperty);
            return instance;
        }

        internal static CustomDrawer Create<T>(InspectorMaidAttribute attribute, UObject target, MemberInfo info, SerializedProperty serializedProperty = null) where T : InspectorMaidAttribute
        {
            var type = typeof(T);
            return Create(type, attribute, target, info, serializedProperty);
        }
    }
}
