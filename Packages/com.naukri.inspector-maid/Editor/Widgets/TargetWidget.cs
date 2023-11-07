using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.UIElements;
using System;
using System.Reflection;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public class TargetWidget : VisualWidgetOf<TargetAttribute>
    {// Tod: check
        public override VisualElement Build(IBuildContext context)
        {
            return CreateTargetElement(context);
        }

        private VisualElement CreateTargetElement(IBuildContext context)
        {
            var memberContext = context.GetContextOfAncestorWidget<MemberWidget>();
            var memberWidget = (MemberWidget)memberContext.Widget;
            var familyContexts = memberContext.GetFamilyContexts();

            VisualElement targetElement = memberWidget.info switch
            {
                // we need to copy serializedProperty, otherwise the slot may not work correctly.
                FieldInfo fieldInfo => new PropertyField(memberWidget.serializedProperty?.Copy()),
                PropertyInfo propertyInfo => new PropertyElement(memberWidget.target, propertyInfo),
                MethodInfo methodInfo => new MethodElement(memberWidget.target, methodInfo),
                _ => throw new InvalidOperationException($"Can not create targetElement because info is not a {nameof(FieldInfo)}, {nameof(PropertyInfo)} or {nameof(MethodInfo)}.")
            };

            foreach (var ctx in familyContexts)
            {
                ctx.SendEvent<ITargetCreatedReceiver>(r => r.OnTargetCreated(ctx, targetElement));
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
