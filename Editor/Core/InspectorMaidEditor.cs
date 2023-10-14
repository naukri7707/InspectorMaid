using Naukri.InspectorMaid.Core;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    [CustomEditor(typeof(Object), true, isFallback = true)]
    internal class InspectorMaidEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var componentContainer = new VisualElement() { name = "component" };

            // fields
            var fieldsContainer = new VisualElement() { name = "fields" };
            var iterator = serializedObject.GetIterator();
            if (iterator.NextVisible(true))
            {
                do
                {
                    var propertyField = new PropertyField(iterator.Copy()) { name = $"PropertyField:{iterator.propertyPath}" };

                    if (iterator.propertyPath == "m_Script" && serializedObject.targetObject != null)
                    {
                        propertyField.SetEnabled(false);
                    }

                    fieldsContainer.Add(propertyField);
                }
                while (iterator.NextVisible(false));
            }

            var type = target.GetType();

            // properties
            var propertiesContainer = new VisualElement() { name = "properties" };
            var propertyInfos = type.GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetCustomAttribute<InspectorMaidAttribute>() != null)
                {
                    var propertyDrawer = new CustomPropertyDrawer(target, propertyInfo);
                    var propertyGUI = propertyDrawer.CreatePropertyGUI();
                    propertiesContainer.Add(propertyGUI);
                }
            }

            // methods
            var methodsContainer = new VisualElement() { name = "methods" };
            var methodInfos = type.GetMethods();

            foreach (var methodInfo in methodInfos)
            {
                if (methodInfo.GetCustomAttribute<InspectorMaidAttribute>() != null)
                {
                    var methodDrawer = new CustomMethodDrawer(target, methodInfo);
                    var methodGUI = methodDrawer.CreatePropertyGUI();
                    methodsContainer.Add(methodGUI);
                }
            }

            componentContainer.Add(fieldsContainer);
            componentContainer.Add(propertiesContainer);
            componentContainer.Add(methodsContainer);

            return componentContainer;
        }
    }
}
