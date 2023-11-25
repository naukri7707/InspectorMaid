using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEditor;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    [CustomPropertyDrawer(typeof(IInspectorMaidTarget), true)]
    public class InspectorMaidPropertyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                // Draw default property field simply if property type is UObject.
                return null;
            }
            else
            {
                var target = property.GetObject();
                var classContext = InspectorMaidUtility.CreateClassContext(target, property);
                var classElement = classContext.Build();

                // Register callbacks
                var editorEventService = ICallbackService.Of(classContext);
                editorEventService.RegisterCallback(classElement);

                // Wrap class element with foldout
                var foldout = new Foldout
                {
                    text = property.displayName
                };

                new ComposerOf(classElement)
                {
                    children = new VisualElement[]
                    {
                        foldout
                    }
                };

                return foldout;
            }
        }
    }
}
