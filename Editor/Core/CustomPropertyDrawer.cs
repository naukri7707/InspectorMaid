using Naukri.InspectorMaid.Editor.UIElements;
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

            var root = Utility.DrawDecoratorTree(target, propertyInfo, drawer => drawer.OnDrawProperty(property));

            // Build the property
            property.Build();

            return root;
        }
    }
}
