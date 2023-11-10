using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.Services.Default;
using Naukri.InspectorMaid.Editor.Widgets.Logic;
using Naukri.InspectorMaid.Editor.Widgets.Visual;
using UnityEditor;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract partial class InspectorMaidEditor : UnityEditor.Editor
    {
        private IEditorEventService editorEventService;

        public override VisualElement CreateInspectorGUI()
        {
            var classContext = CreateContextTree(target);

            editorEventService = IEditorEventService.Of(classContext);

            EditorApplication.update += editorEventService.InvokeUpdate;

            return classContext.Build();
        }

        protected virtual void OnSceneGUI()
        {
            editorEventService?.InvokeSceneGUI();
        }

        protected virtual void OnDestroy()
        {
            if (editorEventService != null)
            {
                EditorApplication.update -= editorEventService.InvokeUpdate;
                editorEventService.InvokeDestroy();
            }
        }
    }

    partial class InspectorMaidEditor
    {
        public static VisualContext CreateContextTree(UObject target)
        {
            var serializedObject = new SerializedObject(target);

            var serviceWidget = new ServiceWidget();
            var serviceContext = serviceWidget.CreateContext();

            var settings = InspectorMaidSettings.Instance;
            var editorEventService = new EditorEventService();
            var fastReflectionService = new FastReflectionService(target);
            var memberWidgetTemplateService = new MemberWidgetTemplates(target, serializedObject);
            var valueChangedListenerService = new ChangedNotifierService(editorEventService, fastReflectionService);

            serviceWidget.AddService<IInspectorMaidSettings>(settings);
            serviceWidget.AddService<IEditorEventService>(editorEventService);
            serviceWidget.AddService<IFastReflectionService>(fastReflectionService);
            serviceWidget.AddService<IMemberWidgetTemplates>(memberWidgetTemplateService);
            serviceWidget.AddService<IChangedNotifierService>(valueChangedListenerService);

            var classWidget = new ClassWidget(target, serializedObject);
            var classContext = classWidget.CreateContext();

            serviceContext.Attach(classContext);

            return classContext;
        }
    }
}
