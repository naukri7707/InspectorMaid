using Naukri.InspectorMaid.Editor.Helpers;
using System;
using System.Collections;
using System.Reflection;
using UnityEditor;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class SerializedPropertyExtensions
    {
        public static FieldInfo GetFieldInfo(this SerializedProperty property)
        {
            var target = property.serializedObject.targetObject;
            var type = target.GetType();
            var fieldInfo = type.GetFieldToBase(InspectorMaidUtility.kBaseType, property.propertyPath);

            return fieldInfo;
        }

        public static bool TryGetFieldInfo(this SerializedProperty property, out FieldInfo fieldInfo)
        {
            var target = property.GetContainerObject();

            if (target == null)
            {
                fieldInfo = null;
                return false;
            }

            var type = target.GetType();
            fieldInfo = type.GetFieldToBase(typeof(object), property.name);

            return fieldInfo != null;
        }

        public static object GetObject(this SerializedProperty self)
        {
            if (self == null)
                return null;

            var target = self.serializedObject.targetObject;

            var path = self.propertyPath.Replace(".Array.data[", "[");
            var partNames = path.Split('.');

            return GetObjectFrom(target, partNames);
        }

        public static object GetContainerObject(this SerializedProperty prop)
        {
            var target = prop.serializedObject.targetObject;
            var path = prop.propertyPath.Replace(".Array.data[", "[");

            // skip last part, so we can get property's object container (an array or object).
            var partNames = path.Split('.')[..^1];

            return GetObjectFrom(target, partNames);
        }

        private static object GetObjectFrom(UObject target, params string[] partNames)
        {
            object current = target;

            foreach (var partName in partNames)
            {
                // Is Array
                if (partName.Contains("["))
                {
                    var elementName = partName[..partName.IndexOf("[")];

                    var from = partName.IndexOf('[');
                    var to = partName.IndexOf(']');
                    var index = int.Parse(partName[(from + 1)..to]);

                    current = GetValueOfArray(current, elementName, index);
                }
                else
                {
                    current = GetValue(current, partName);
                }
            }
            return current;
        }

        private static object GetValueOfArray(object obj, string arrayName, int index)
        {
            if (obj == null)
            {
                return null;
            }

            if (GetValue(obj, arrayName) is IList list)
            {
                return list[index];
            }
            else
            {
                throw new Exception($"target must implement {nameof(IList)}");
            }
        }

        private static object GetValue(object obj, string name)
        {
            if (obj == null)
            {
                return null;
            }

            var fieldInfo = obj.GetType().GetFieldToBase(null, name);

            return fieldInfo.GetValue(obj);
        }
    }
}
