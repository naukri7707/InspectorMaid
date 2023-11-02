using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Events;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.UIElements;
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

        private InspectorMaidSettings settings;

        public override VisualElement CreateInspectorGUI()
        {
            root = new();
            root.RegisterCallback<RepaintEvent>(evt =>
            {
                editorEventService?.OnSceneGUI();
            });

            editorEventService = new();
            settings = InspectorMaidSettings.Instance;

            root.AddService<TemplateService>();
            root.AddService(editorEventService);
            root.AddService(settings);

            var styleSheets = settings.importStyleSheets;
            foreach (var sheet in styleSheets)
            {
                root.styleSheets.Add(sheet);
            }

            // fields
            var iterator = serializedObject.GetIterator();
            if (iterator.NextVisible(true))
            {
                do
                {
                    var fieldElement = new PropertyField(iterator.Copy()) { name = $"PropertyField:{iterator.propertyPath}" };
                    if (iterator.propertyPath == "m_Script" && serializedObject.targetObject != null)
                    {
                        fieldElement.SetEnabled(false);
                        root.Add(fieldElement);
                        continue;
                    }
                    var fieldInfo = iterator.GetFieldInfo();

                    if (fieldInfo.HasAttribute<WidgetAttribute>())
                    {
                        var widgetTree = new WidgetTree(target, fieldInfo, iterator);

                        root.Add(widgetTree);
                    }
                    else
                    {
                        root.Add(fieldElement);
                    }
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
                    var widgetTree = new WidgetTree(target, propertyInfo);

                    root.Add(widgetTree);
                }
            }

            // methods
            var methodInfos = type.GetMethods(Utility.AllAccessFlags);

            foreach (var methodInfo in methodInfos)
            {
                if (methodInfo.HasAttribute<WidgetAttribute>())
                {
                    var widgetTree = new WidgetTree(target, methodInfo);

                    root.Add(widgetTree);
                }
            }

            var widgetTrees = root.Query<WidgetTree>().ToList();

            // register all widgetTree as a template before widgetTree Build,
            // so we can use it in other widgetTree on build.
            foreach (var widgetTree in widgetTrees)
            {
                widgetTree.RegisterTemplate();
            }

            // we need to build widget tree before return to CreateInspectorGUI,
            // otherwise, the `PropertyField` VisualElement will not be displayed.
            foreach (var widgetTree in widgetTrees)
            {
                if (!widgetTree.ShouldBuildAtRoot)
                {
                    continue;
                }

                widgetTree.Build();
            }

            // Awake all widget,
            for (int i = 0; i < settings.maxNestingDepth; i++)
            {
                var widgets = root.Query<Widget>().Where(it => it.LifePhase == WidgetLifePhase.Created).ToList();

                if (widgets.Count == 0)
                {
                    break;
                }

                // send OnAwake event to all widget
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
