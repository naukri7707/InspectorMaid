using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Naukri.InspectorMaid.Core;
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
            var builder = new MethodBuilder(target, methodInfo, name);

            var drawers = methodInfo.GetCustomAttributes<InspectorMaidAttribute>(true)
                .OrderByDescending(it => it.order)
                .Select(it => DrawerTemplates.Create(it.GetType(), it, target, methodInfo))
                .ToList();

            // Style the method
            foreach (var drawer in drawers)
            {
                drawer.OnDrawMethod(builder);
            }

            var method = builder.Build();

            // Decorate the method
            var decorator = new DecoratorElement("Method Decorator");
            decorator.Add(method);

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
