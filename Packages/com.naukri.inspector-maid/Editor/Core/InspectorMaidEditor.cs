﻿using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Events;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.Services;
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
        private InspectorMaidElement root;

        private EditorEventService editorEventService;

        private TemplateService templateService;

        private InspectorMaidSettings settings;

        public override VisualElement CreateInspectorGUI()
        {
            root = new();
            root.RegisterCallback<RepaintEvent>(evt =>
            {
                editorEventService?.OnSceneGUI();
            });

            editorEventService = new();
            templateService = new();
            settings = InspectorMaidSettings.Instance;
            var fastReflectionService = new FastReflectionService(target);

            root.AddService(templateService);
            root.AddService(editorEventService);
            root.AddService(settings);
            root.AddService(fastReflectionService);

            var styleSheets = settings.importStyleSheets;
            foreach (var sheet in styleSheets)
            {
                root.styleSheets.Add(sheet);
            }

            var widgetTreeDrawers = new List<WidgetTreeDrawer>();

            // fields
            var iterator = serializedObject.GetIterator();
            if (iterator.NextVisible(true))
            {
                do
                {
                    // special case for m_Script: draw by default drawer and disable it
                    var fieldElement = new PropertyField(iterator.Copy()) { name = $"PropertyField:{iterator.propertyPath}" };
                    if (iterator.propertyPath == "m_Script" && serializedObject.targetObject != null)
                    {
                        fieldElement.SetEnabled(false);
                        root.Add(fieldElement);
                        continue;
                    }

                    // wrap all field with WidgetTreeDrawer, even if it is not a widget
                    // so we can inject any target to slot as widget
                    var fieldInfo = iterator.GetFieldInfo();
                    var widgetTreeDrawer = new WidgetTreeDrawer(target, fieldInfo, iterator);

                    widgetTreeDrawers.Add(widgetTreeDrawer);
                }
                while (iterator.NextVisible(false));
            }

            var type = target.GetType();

            // properties
            var propertyInfos = type.GetProperties(Utility.AllAccessFlags);

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.HasAttribute<WidgetAttribute>())
                {
                    var widgetTreeDrawer = new WidgetTreeDrawer(target, propertyInfo);
                    widgetTreeDrawers.Add(widgetTreeDrawer);
                }
            }

            // methods
            var methodInfos = type.GetMethods(Utility.AllAccessFlags);

            foreach (var methodInfo in methodInfos)
            {
                if (methodInfo.HasAttribute<WidgetAttribute>())
                {
                    var widgetTreeDrawer = new WidgetTreeDrawer(target, methodInfo);
                    widgetTreeDrawers.Add(widgetTreeDrawer);
                }
            }

            // register all widgetTree as a template before widgetTree Build,
            // so we can use it in other widgetTree on build.
            foreach (var widgetTreeDrawer in widgetTreeDrawers)
            {
                widgetTreeDrawer.RegisterTemplate(templateService);
            }

            // we need to build widget tree before return to CreateInspectorGUI,
            // otherwise, the `PropertyField` VisualElement will not be displayed.
            foreach (var widgetTreeDrawer in widgetTreeDrawers)
            {
                if (!widgetTreeDrawer.ShouldBuildAtRoot)
                {
                    continue;
                }

                var widget = widgetTreeDrawer.CreateWidget();
                root.Add(widget);
            }

            // Awake all widget, because of nesting slot, we should awake several times.
            for (int i = 0; i < settings.maxNestingDepth; i++)
            {
                var widgets = root.Query<Widget>().Where(it => it.LifePhase == WidgetLifePhase.Created).ToList();

                // If no more widget need to awake, break the loop.
                if (widgets.Count == 0)
                {
                    break;
                }

                // send Awake event to all widget
                // we need to send this event after all widgetTree build,
                foreach (var widget in widgets)
                {
                    widget.SendEvent<IAwakeReceiver>(r => r.OnAwake(widget));
                    widget.LifePhase = WidgetLifePhase.Awaked;
                }
            }

            return root;
        }

        protected void OnDestroy()
        {
            editorEventService?.OnDestroy();
        }

        protected void OnSceneGUI()
        {
            editorEventService?.OnSceneGUI();
        }
    }
}
