using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.UIElements;
using System;
using System.Reflection;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class TargetWidget : WidgetOf<TargetAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            return CreateTargetElement(context);
        }

        private VisualElement CreateTargetElement(IBuildContext context)
        {
            var memberWidgetElement = context.GetElementOfAncestorWidget<MemberWidget>();
            var memberWidget = (MemberWidget)memberWidgetElement.Widget;

            VisualElement targetElement = memberWidget.info switch
            {
                FieldInfo fieldInfo => new PropertyField(memberWidget.serializedProperty?.Copy()),
                PropertyInfo propertyInfo => new PropertyElement(memberWidget.target, propertyInfo),
                MethodInfo methodInfo => new MethodElement(memberWidget.target, methodInfo),
                _ => throw new InvalidOperationException($"Can not create targetElement because info is not a {nameof(FieldInfo)}, {nameof(PropertyInfo)} or {nameof(MethodInfo)}.")
            };

            var elements = memberWidget.GetFamily(memberWidgetElement);

            foreach (var e in elements)
            {
                e.SendEvent<ITargetCreatedReceiver>(r => r.OnTargetCreated(e, targetElement));
            }

            if (targetElement is PropertyElement propertyElement)
            {
                propertyElement.Build();
            }
            else if (targetElement is MethodElement methodElement)
            {
                methodElement.Build();
            }

            return targetElement;
        }
    }
}
