﻿using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Events;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.UIElements;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    [CustomEditor(typeof(MonoBehaviour), true, isFallback = true)]
    internal class InspectorMaidEditor : UnityEditor.Editor
    {
        private VisualElement componentContainer;

        public void RR()
        {
            componentContainer.SendEvent(new ChangeEvent<int>());
        }

        public override VisualElement CreateInspectorGUI()
        {
            componentContainer = new VisualElement() { name = "Component" };
            var styleSheets = InspectorMaidSettings.Instance.importStyleSheets;
            foreach (var sheet in styleSheets)
            {
                componentContainer.styleSheets.Add(sheet);
            }

            // fields
            var fieldsContainer = new VisualElement() { name = "Fields" };
            var iterator = serializedObject.GetIterator();
            if (iterator.NextVisible(true))
            {
                do
                {
                    var propertyField = new PropertyField(iterator.Copy()) { name = $"PropertyField:{iterator.propertyPath}" };

                    if (iterator.propertyPath == "m_Script" && serializedObject.targetObject != null)
                    {
                        propertyField.SetEnabled(false);
                        fieldsContainer.Add(propertyField);
                        continue;
                    }
                    var fieldInfo = iterator.GetFieldInfo();

                    if (fieldInfo.HasAttribute<DecoratorAttribute>())
                    {
                        var fieldDrawer = new CustomFieldDrawer(target, fieldInfo, propertyField);
                        var fieldGUI = fieldDrawer.CreateFieldGUI();
                        fieldsContainer.Add(fieldGUI);
                    }
                    else
                    {
                        fieldsContainer.Add(propertyField);
                    }
                }
                while (iterator.NextVisible(false));
            }

            var type = target.GetType();

            // properties
            var propertiesContainer = new VisualElement() { name = "Properties" };
            var propertyInfos = type.GetProperties(Utility.AllAccessFlags);

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.HasAttribute<DecoratorAttribute>())
                {
                    var propertyDrawer = new CustomPropertyDrawer(target, propertyInfo);
                    var propertyGUI = propertyDrawer.CreatePropertyGUI();
                    propertiesContainer.Add(propertyGUI);
                }
            }

            // methods
            var methodsContainer = new VisualElement() { name = "Methods" };
            var methodInfos = type.GetMethods(Utility.AllAccessFlags);

            foreach (var methodInfo in methodInfos)
            {
                if (methodInfo.HasAttribute<DecoratorAttribute>())
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
                    Decorator.InvokeOnDestroy(decorator);
                }
            }
        }

        protected void OnSceneGUI()
        {
            var needRepaint = true;
            while (needRepaint)
            {
                needRepaint = false;
                if (TryGetDecoratorElements(out var decorators))
                {
                    foreach (var decorator in decorators)
                    {
                        if (!decorator.IsStarted)
                        {
                            decorator.RegisterCallback<RepaintEvent>(evt => OnSceneGUI());
                            Decorator.InvokeOnStart(decorator);
                            decorator.IsStarted = true;
                        }
                        Decorator.InvokeOnSceneGUI(decorator);
                    }
                }
            }
        }

        private bool TryGetDecoratorElements(out IEnumerable<Decorator> decorators)
        {
            if (componentContainer == null)
            {
                decorators = null;
                return false;
            }
            else
            {
                decorators = componentContainer.Query<Decorator>().ToList();
                return true;
            }
        }
    }
}
