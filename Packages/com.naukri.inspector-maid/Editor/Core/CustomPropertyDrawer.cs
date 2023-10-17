using System.Linq;
using System.Reflection;
using Naukri.InspectorMaid.Core;
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
            var builder = new PropertyBuilder(target, propertyInfo, name);

            var drawers = propertyInfo.GetCustomAttributes<InspectorMaidAttribute>(true)
                .OrderByDescending(it => it.order)
                .Select(it => DrawerTemplates.Create(it.GetType(), it, target, propertyInfo))
                .ToList();

            // Style the property
            foreach (var drawer in drawers)
            {
                drawer.OnDrawProperty(builder);
            }

            var property = builder.Build();

            // Decorate the property
            var decorator = new DecoratorElement("Property Decorator");
            decorator.Add(property);

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
