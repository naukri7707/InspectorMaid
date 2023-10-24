using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using Naukri.InspectorMaid.Style;
using System.Collections.Generic;
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

            var drawers = new List<CustomDrawer>();
            var attrs = propertyInfo.GetCustomAttributes<InspectorMaidAttribute>(true)
                .ToList();

            // Decorate the property
            var decorator = new DecoratorElement("Property Decorator");
            decorator.Add(property);

            foreach (var attr in attrs)
            {
                // Draw decorator
                if (attr is DrawerAttribute drawerAttr)
                {
                    var drawer = DrawerTemplates.Create(drawerAttr, DrawerTarget.Field, target, propertyInfo);
                    drawers.Add(drawer);

                    drawer.OnDrawDecorator(decorator);
                    decorator = drawer.decoratorRef;
                }
                // Style decorator
                else if (attr is StylerAttribute styleAttr)
                {
                    // Special processing ClassAttribute
                    if (attr is ClassAttribute classAttr)
                    {
                        foreach (var className in classAttr.classNames)
                        {
                            decorator.AddToClassList(className);
                        }
                    }
                    else
                    {
                        var styler = StylerTemplates.Create(styleAttr);
                        styler.OnStyling(decorator.style);
                    }
                }
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
