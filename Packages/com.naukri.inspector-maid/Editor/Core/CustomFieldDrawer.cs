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
            var field = new PropertyField(property);
            var target = property.serializedObject.targetObject;

            var drawers = fieldInfo.GetCustomAttributes<InspectorMaidAttribute>(true)
                .OrderByDescending(it => it.order)
                .Select(it => DrawerTemplates.Create(it.GetType(), it, target, fieldInfo))
                .ToList();

            // Style the field
            foreach (var drawer in drawers)
            {
                drawer.OnDrawField(field);
            }

            // Decorate the field
            var decorator = new DecoratorElement("Field Decorator");
            decorator.Add(field);

            foreach (var drawer in drawers)
            {
                decorator = drawer.OnDrawDecorator(decorator);

                if (decorator == null)
                {
                    throw new System.Exception($"Decorator is null. {drawer.GetType().Name} is not allowed to return null.");
                }
            }

            return decorator;
        }
    }
}
