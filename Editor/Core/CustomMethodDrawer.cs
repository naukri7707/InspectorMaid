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
    internal class CustomMethodDrawer
    {
        internal CustomMethodDrawer(UObject target, MethodInfo methodInfo)
        {
            this.target = target;
            this.methodInfo = methodInfo;
        }

        public readonly MethodInfo methodInfo;

        public readonly UObject target;

        public VisualElement CreatePropertyGUI()
        {
            var name = ObjectNames.NicifyVariableName(methodInfo.Name);
            var method = new MethodElement(name, target, methodInfo);

            var drawers = new List<CustomDrawer>();
            var attrs = methodInfo.GetCustomAttributes<InspectorMaidAttribute>(true)
                .ToList();

            // Decorate the method
            var decorator = new DecoratorElement("Method Decorator");
            decorator.Add(method);

            foreach (var attr in attrs)
            {
                // Draw decorator
                if (attr is DrawerAttribute drawerAttr)
                {
                    var drawer = DrawerTemplates.Create(drawerAttr, DrawerTarget.Field, target, methodInfo);
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

            // Style the method
            foreach (var drawer in drawers)
            {
                drawer.OnDrawMethod(method);
            }

            // Build the method
            method.Build();

            return decorator;
        }
    }
}
