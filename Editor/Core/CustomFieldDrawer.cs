using Naukri.InspectorMaid.Core;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    [UnityEditor.CustomPropertyDrawer(typeof(InspectorMaidAttribute), true)]
    internal class CustomFieldDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var sortedAttrs = fieldInfo.GetCustomAttributes<InspectorMaidAttribute>(true).OrderByDescending(it => it.order);

            var field = new PropertyField(property);

            var args = new FieldDrawerArgs(property.serializedObject.targetObject, fieldInfo, property);

            VisualElement ve = field;

            foreach (var attr in sortedAttrs)
            {
                var drawer = DrawerMapper.Get(attr.GetType());

                drawer.OnDrawField(field, attr, args);
                var decorator = drawer.OnDrawDecorator(ve, attr, args);
                if (decorator != null)
                {
                    ve = decorator;
                }
            }
            return ve;
        }
    }
}
