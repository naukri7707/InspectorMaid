﻿using Naukri.InspectorMaid.Editor.Helpers;
using System.Reflection;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class SerializedPropertyExtensions
    {
        public static FieldInfo GetFieldInfo(this SerializedProperty property)
        {
            var target = property.serializedObject.targetObject;
            var type = target.GetType();
            var fieldInfo = type.GetFieldToBase(InspectorMaidUtility.BaseType, property.propertyPath);

            return fieldInfo;
        }

        public static bool TryGetFieldInfo(this SerializedProperty property, out FieldInfo fieldInfo)
        {
            var target = property.serializedObject.targetObject;
            var type = target.GetType();
            fieldInfo = type.GetFieldToBase(typeof(object), property.propertyPath);

            return fieldInfo != null;
        }
    }
}