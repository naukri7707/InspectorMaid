using Naukri.InspectorMaid.Core;
using System.Linq;
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

            var drawers = fieldInfo.GetCustomAttributes<InspectorMaidAttribute>(true)
                .OrderByDescending(it => it.order)
                .Select(it => DrawerTemplates.Create(it.GetType(), DrawerTarget.Field, it, target, fieldInfo))
                .ToList();

            // Decorate the field
            var decorator = new DecoratorElement("Field Decorator");
            decorator.Add(field);

            foreach (var drawer in drawers)
            {
                drawer.OnDrawDecorator(decorator);
                decorator = drawer.decoratorRef;
            }

            // Style the field
            foreach (var drawer in drawers)
            {
                drawer.OnDrawField(field);
            }

            return decorator;
        }
    }
}
