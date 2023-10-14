using System.Reflection;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Core
{
    public class FieldDrawerArgs : DrawerArgs
    {
        public FieldDrawerArgs(object target, FieldInfo fieldInfo, SerializedProperty property)
        {
            this.target = target;
            this.fieldInfo = fieldInfo;
            this.property = property;
        }

        public readonly FieldInfo fieldInfo;

        public readonly SerializedProperty property;

        public readonly object target;
    }
}
