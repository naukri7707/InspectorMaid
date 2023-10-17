using System.Collections.Generic;
using System.Reflection;
using Naukri.InspectorMaid.Core;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    [CustomEditor(typeof(Object), true, isFallback = true)]
    internal class InspectorMaidEditor : UnityEditor.Editor
    {
        private VisualElement componentContainer;

        private bool isStarted;

        public override VisualElement CreateInspectorGUI()
        {
            componentContainer = new VisualElement() { name = "component" };

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
            var propertyInfos = type.GetProperties(Utility.AllAccessFlags);

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
            var methodInfos = type.GetMethods(Utility.AllAccessFlags);

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

        protected void OnDestroy()
        {
            if (TryGetDecoratorElements(out var decorators))
            {
                foreach (var decorator in decorators)
                {
                    DecoratorElement.InvokeOnDestroy(decorator);
                }
            }
        }

        protected void OnSceneGUI()
        {
            if (TryGetDecoratorElements(out var decorators))
            {
                if (!isStarted)
                {
                    foreach (var decorator in decorators)
                    {
                        DecoratorElement.InvokeOnStart(decorator);
                    }
                    isStarted = true;
                }

                foreach (var decorator in decorators)
                {
                    DecoratorElement.InvokeOnSceneGUI(decorator);
                }
            }
        }

        private bool TryGetDecoratorElements(out IEnumerable<DecoratorElement> decorators)
        {
            if (componentContainer == null)
            {
                decorators = null;
                return false;
            }
            else
            {
                decorators = componentContainer.Query<DecoratorElement>().ToList();
                return true;
            }
        }
    }
}
