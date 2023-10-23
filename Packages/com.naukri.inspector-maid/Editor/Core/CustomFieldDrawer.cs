using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using System.Collections.Generic;
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

            var drawers = new List<CustomDrawer>();
            var attrs = fieldInfo.GetCustomAttributes<InspectorMaidAttribute>(true)
                .ToList();

            attrs.Reverse();

            // Decorate the field
            var decorator = new DecoratorElement("Field Decorator");
            decorator.Add(field);

            foreach (var attr in attrs)
            {
                // Draw decorator
                if (attr is DrawerAttribute drawerAttr)
                {
                    var drawer = DrawerTemplates.Create(drawerAttr, DrawerTarget.Field, target, fieldInfo);
                    drawers.Add(drawer);

                    drawer.OnDrawDecorator(decorator);
                    decorator = drawer.decoratorRef;
                }
                // Style decorator
                else if (attr is StylerAttribute styleAttr)
                {
                    var styler = StylerTemplates.Create(styleAttr);
                    styler.OnStyling(decorator.style);
                }
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
