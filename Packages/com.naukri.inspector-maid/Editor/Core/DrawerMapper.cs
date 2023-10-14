using Naukri.InspectorMaid.Core;
using System;
using System.Collections.Generic;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Core
{
    internal static class DrawerMapper
    {
        private static Dictionary<Type, CustomDrawer> _dict;

        private static Dictionary<Type, CustomDrawer> Dict
        {
            get
            {
                if (_dict == null)
                {
                    _dict = new Dictionary<Type, CustomDrawer>();
                    var drawerTypes = TypeCache.GetTypesDerivedFrom(typeof(CustomDrawerOf<>));
                    foreach (var type in drawerTypes)
                    {
                        var inst = (CustomDrawer)Activator.CreateInstance(type);
                        _dict[inst.AttributeType] = inst;
                    }
                }
                return _dict;
            }
        }

        internal static CustomDrawer Get<T>() where T : InspectorMaidAttribute
        {
            return Get(typeof(T));
        }

        internal static CustomDrawer Get(Type type)
        {
            return Dict[type];
        }
    }
}
