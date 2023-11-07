using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.Services.Common;
using Naukri.InspectorMaid.Editor.Widgets;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    [CustomEditor(typeof(MonoBehaviour), true, isFallback = true)]
    internal class InspectorMaidEditor : UnityEditor.Editor
    {
        EditorEventService editorEventService;

        public override VisualElement CreateInspectorGUI()
        {
            var serviceWidget = new ServiceWidget();

            editorEventService = new EditorEventService();

            EditorApplication.update += editorEventService.InvokeUpdate;

            var settings = InspectorMaidSettings.Instance;
            var fastReflectionService = new FastReflectionService(target);
            var memberWidgetTemplateService = new MemberWidgetTemplates();
            var valueChangedListenerService = new ChangedNotifierService(editorEventService, fastReflectionService);

            serviceWidget.AddService<IInspectorMaidSettings>(settings);
            serviceWidget.AddService<IEditorEventService>(editorEventService);
            serviceWidget.AddService<IFastReflectionService>(fastReflectionService);
            serviceWidget.AddService<IMemberWidgetTemplates>(memberWidgetTemplateService);
            serviceWidget.AddService<IChangedNotifierService>(valueChangedListenerService);

            var root = new ClassWidget(target, serializedObject);

            var serviceContext = serviceWidget.CreateContext();

            var rootContext = root.CreateContext();

            rootContext.AttachParent(serviceContext);

            return rootContext.Build();
        }

        protected virtual void OnSceneGUI()
        {
            editorEventService?.InvokeSceneGUI();
        }

        protected virtual void OnDestroy()
        {
            EditorApplication.update -= editorEventService.InvokeUpdate;
            editorEventService.InvokeDestroy();
        }
    }
}
