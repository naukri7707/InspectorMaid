using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class InspectorMaidEditor : UnityEditor.Editor
    {
        private ICallbackService editorEventService;

        public override VisualElement CreateInspectorGUI()
        {
            var classContext = InspectorMaidUtility.CreateClassContext(target, serializedObject.GetIterator());

            // Build class element
            var classElement = classContext.Build();

            // Add script field
            var scriptField = new ScriptField(serializedObject);
            classElement.Insert(0, scriptField);

            // Register callbacks
            editorEventService = ICallbackService.Of(classContext);
            editorEventService.RegisterCallback(classElement);

            return classElement;
        }
    }
}
