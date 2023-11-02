using Naukri.InspectorMaid.Editor.Helpers;
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
            var fieldInfo = type.GetField(property.propertyPath, Utility.AllAccessFlags);

            return fieldInfo;
        }
    }
}
