using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public partial class ClassWidget : ScopeWidget, IContextAttachedReceiver
    {
        public ClassWidget(UObject target, SerializedObject serializedObject)
        {
            this.target = target;
            this.serializedObject = serializedObject;
        }

        public UObject target;

        public SerializedObject serializedObject;

        public override VisualElement Build(IBuildContext context)
        {
            var container = new VisualElement();

            BuildChildren(context, (ctx, e) =>
            {
                container.Add(e);
            });

            var settings = IInspectorMaidSettings.Of(context);
            var styleSheets = settings.ImportStyleSheets;

            foreach (var sheet in styleSheets)
            {
                container.styleSheets.Add(sheet);
            }

            return container;
        }

        public void OnContextAttached(Context context)
        {
            var templateService = IMemberWidgetTemplates.Of(context);

            var type = target.GetType();
            var scriptFieldWidget = new ScriptFieldWidget(serializedObject.FindProperty("m_Script"));
            var memberWidgets = new List<MemberWidget>();

            // fields
            var iterator = serializedObject.GetIterator();
            if (iterator.NextVisible(true))
            {
                do
                {
                    // we need to skip unsupported serialized property like m_Script
                    if (iterator.TryGetFieldInfo(out FieldInfo fieldInfo))
                    {
                        // wrap all field with MemberWidget, even if it is not a widget
                        // so we can inject any target to slot as widget
                        var memberWidget = new MemberWidget(target, fieldInfo, iterator);
                        memberWidgets.Add(memberWidget);
                    }
                }
                while (iterator.NextVisible(false));
            }

            // properties
            var propertyInfos = type.GetPropertiesFromBase(InspectorMaidUtility.kBaseType);

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.HasAttribute<WidgetAttribute>())
                {
                    var memberWidget = new MemberWidget(target, propertyInfo);
                    memberWidgets.Add(memberWidget);
                }
            }

            // methods
            var methodInfos = type.GetMethodsFromBase(InspectorMaidUtility.kBaseType);

            foreach (var methodInfo in methodInfos)
            {
                if (methodInfo.HasAttribute<WidgetAttribute>())
                {
                    var memberWidget = new MemberWidget(target, methodInfo);
                    memberWidgets.Add(memberWidget);
                }
            }

            // we need to add all member widgets to template service first,
            // so that we can use them in slot
            foreach (var memberWidget in memberWidgets)
            {
                templateService.Register(memberWidget);
            }

            // create script field widget
            var scriptFieldContext = scriptFieldWidget.CreateContext();
            scriptFieldContext.AttachParent(context);

            // create member widgets
            foreach (var memberWidget in memberWidgets)
            {
                // don't create template widget
                if (memberWidget.IsTemplate)
                {
                    continue;
                }
                var memberContext = memberWidget.CreateContext();
                memberContext.AttachParent(context);
            }
        }
    }

    partial class ClassWidget
    {
        public static ClassWidget Of(IBuildContext context)
        {
            return context.GetAncestorWidget<ClassWidget>();
        }
    }
}
