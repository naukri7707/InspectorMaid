using Naukri.InspectorMaid.Core;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    internal class CustomPropertyDrawer
    {
        internal CustomPropertyDrawer(UObject target, PropertyInfo propertyInfo)
        {
            this.target = target;
            this.propertyInfo = propertyInfo;
        }

        public readonly PropertyInfo propertyInfo;

        public readonly UObject target;

        public VisualElement CreatePropertyGUI()
        {
            var name = ObjectNames.NicifyVariableName(propertyInfo.Name);
            var property = new PropertyElement(name, target, propertyInfo);

            var drawers = propertyInfo.GetCustomAttributes<InspectorMaidAttribute>(true)
                .OrderByDescending(it => it.order)
                .Select(it => DrawerTemplates.Create(it.GetType(), DrawerTarget.Property, it, target, propertyInfo))
                .ToList();

            // Decorate the property
            var decorator = new DecoratorElement("Property Decorator");
            decorator.Add(property);

            foreach (var drawer in drawers)
            {
                drawer.OnDrawDecorator(decorator);
                decorator = drawer.decoratorRef;
            }

            // Style the property
            foreach (var drawer in drawers)
            {
                drawer.OnDrawProperty(property);
            }

            // Build the property
            property.Build();

            return decorator;
        }
    }
}
