using Naukri.InspectorMaid.Core;
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
            var method = new MethodElement(target, methodInfo)
            {
                label = name
            };

            var drawers = methodInfo.GetCustomAttributes<InspectorMaidAttribute>(true)
                .OrderByDescending(it => it.order)
                .Select(it => DrawerTemplates.Create(it.GetType(), DrawerTarget.Method, it, target, methodInfo))
                .ToList();

            // Decorate the method
            var decorator = new DecoratorElement("Method Decorator");
            decorator.Add(method);

            foreach (var drawer in drawers)
            {
                drawer.OnDrawDecorator(decorator);
                decorator = drawer.decoratorRef;
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
