using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.Services.Default;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using Naukri.InspectorMaid.Editor.Widgets.Logic;
using Naukri.InspectorMaid.Editor.Widgets.Visual;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Naukri.InspectorMaid.Editor.Helpers
{
    internal static class InspectorMaidUtility
    {
        public const BindingFlags kAllAccessFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        public const BindingFlags kAllDeclaredAccessFlags = kAllAccessFlags | BindingFlags.DeclaredOnly;

        // this should be same as InspectorMaidEditor's CustomEditor attribute
        public static readonly Type kBaseType = typeof(MonoBehaviour);

        public static VisualContext CreateClassContext(object target, SerializedProperty serializedProperty)
        {
            var serviceWidget = new ServiceWidget();
            var serviceContext = serviceWidget.CreateContext();

            var settings = InspectorMaidSettings.Instance;
            var editorEventService = new CallbackService();
            var fastReflectionService = new FastReflectionService(target);
            var memberWidgetTemplateService = new MemberWidgetTemplates(target, serializedProperty.Copy());
            var valueChangedListenerService = new ChangedNotifierService(editorEventService, fastReflectionService);

            serviceWidget.AddService<IInspectorMaidSettings>(settings);
            serviceWidget.AddService<ICallbackService>(editorEventService);
            serviceWidget.AddService<IFastReflectionService>(fastReflectionService);
            serviceWidget.AddService<IMemberWidgetTemplates>(memberWidgetTemplateService);
            serviceWidget.AddService<IChangedNotifierService>(valueChangedListenerService);

            var classWidget = new ClassWidget(target, serializedProperty.Copy());
            var classContext = classWidget.CreateContext();

            serviceContext.Attach(classContext);

            return classContext;
        }

        public static void CreateWidgetContextsAndAttach(Context parentContext, IEnumerable<WidgetAttribute> widgetAttributes)
        {
            var iteractor = widgetAttributes.GetEnumerator();

            var lastVisualContext = parentContext;

            void BuildContextTree(Context parent)
            {
                while (iteractor.MoveNext())
                {
                    var widgetAttr = iteractor.Current;

                    if (widgetAttr is VisualAttribute)
                    {
                        var childWidget = WidgetBuilder.Create(widgetAttr);
                        var childContext = childWidget.CreateContext();
                        parent.Attach(childContext);

                        lastVisualContext = childContext;

                        if (childWidget is ItemWidget)
                        {
                            // Do nothing
                        }
                        else if (childWidget is ScopeWidget)
                        {
                            BuildContextTree(childContext);
                        }
                    }
                    else if (widgetAttr is LogicAttribute)
                    {
                        // Terminate the loop at the EndScopeAttribute
                        // to exit building from the parent scope.
                        if (widgetAttr is EndScopeAttribute)
                        {
                            break;
                        }

                        // Create and attach the styler widget to last VisualContext.
                        if (widgetAttr is StylerAttribute)
                        {
                            var stylerWidget = WidgetBuilder.Create(widgetAttr);

                            var stylerContext = stylerWidget.CreateContext();
                            lastVisualContext.Attach(stylerContext);
                        }
                    }
                }
            }

            BuildContextTree(parentContext);
        }
    }
}
