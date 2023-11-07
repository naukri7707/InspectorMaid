using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.UIElements;
using System;
using System.Reflection;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class TargetWidget : ItemWidgetOf<TargetAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            return BuildTargetElement(context);
        }

        private VisualElement BuildTargetElement(IBuildContext context)
        {
            var memberContext = context.GetContextOfAncestorWidget<MemberWidget>();
            var memberWidget = (MemberWidget)memberContext.Widget;
            var familyContexts = context.GetFamilyContexts();

            VisualElement targetElement = memberWidget.info switch
            {
                // we need to copy serializedProperty, otherwise the slot may not work correctly.
                FieldInfo fieldInfo => new PropertyField(memberWidget.serializedProperty?.Copy()),
                PropertyInfo propertyInfo => new PropertyElement(memberWidget.target, propertyInfo),
                MethodInfo methodInfo => new MethodElement(memberWidget.target, methodInfo),
                _ => throw new InvalidOperationException($"Can not create targetElement because info is not a {nameof(FieldInfo)}, {nameof(PropertyInfo)} or {nameof(MethodInfo)}.")
            };

            if (targetElement is PropertyElement propertyElement)
            {
                propertyElement.Build();
            }
            else if (targetElement is MethodElement methodElement)
            {
                methodElement.Build();
            }

            foreach (var ctx in familyContexts)
            {
                if (ctx.Widget is ITargetBuildedReceiver receiver)
                {
                    receiver.OnTargetBuilded(ctx, targetElement);
                }
            }

            return targetElement;
        }
    }
}
