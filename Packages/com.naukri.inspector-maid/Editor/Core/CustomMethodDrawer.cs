using Naukri.InspectorMaid.Editor.UIElements;
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

            var root = Utility.DrawDecoratorTree(target, methodInfo, drawer => drawer.OnDrawMethod(method));

            // Build the property
            method.Build();

            return root;
        }
    }
}
