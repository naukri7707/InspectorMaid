using Naukri.InspectorMaid.Editor.Helpers;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    internal class CustomFieldDrawer
    {
        internal CustomFieldDrawer(UObject target, FieldInfo fieldInfo, PropertyField field)
        {
            this.target = target;
            this.fieldInfo = fieldInfo;
            this.field = field;
        }

        public readonly FieldInfo fieldInfo;

        public readonly UObject target;

        private readonly PropertyField field;

        public VisualElement CreateFieldGUI()
        {
            var name = ObjectNames.NicifyVariableName(fieldInfo.Name);
            field.label = name;

            var root = Utility.DrawDecoratorTree(target, fieldInfo, drawer => drawer.OnDrawField(field));

            return root;
        }
    }
}
