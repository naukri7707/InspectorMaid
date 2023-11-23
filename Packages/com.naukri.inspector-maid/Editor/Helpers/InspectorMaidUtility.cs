using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.Services.Default;
using Naukri.InspectorMaid.Editor.Widgets.Logic;
using Naukri.InspectorMaid.Editor.Widgets.Visual;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Helpers
{
    internal static class InspectorMaidUtility
    {
        public const BindingFlags kAllAccessFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        public const BindingFlags kAllDeclaredAccessFlags = kAllAccessFlags | BindingFlags.DeclaredOnly;

        // this should be same as InspectorMaidEditor's CustomEditor attribute
        public static readonly Type kBaseType = typeof(MonoBehaviour);

        public static bool IsBoxedValueEqual(object lhs, object rhs)
        {
            // Because Unity override '==' operator for UObject.
            // So if any of them is UObject, compare them by '==' operator.
            if (lhs is UObject || rhs is UObject)
            {
                var uLhs = lhs as UObject;
                var uRhs = rhs as UObject;
                return uLhs == uRhs;
            }
            // Compare them in other case.
            else
            {
                // Cause of the boxing, we can't use '==' operator, otherwise it will compare them by reference.
                // e.g.
                // object a = 1;
                // object b = 1;
                // bool c = a == b; // c is false
                return Equals(lhs, rhs);
            }
        }

        public static Context CreateClassContext(object target, SerializedProperty serializedProperty)
        {
            var serviceWidget = new ServiceWidget();
            var serviceContext = serviceWidget.CreateContext();

            var settings = InspectorMaidSettings.Instance;
            var callbackService = new CallbackService();

            var fastReflectionService = new FastReflectionService(target);
            var memberWidgetTemplateService = new MemberWidgetTemplates(target, serializedProperty.Copy());
            var valueChangedListenerService = new ChangedNotifierService(callbackService, fastReflectionService);

            serviceWidget.AddService<IInspectorMaidSettings>(settings);
            serviceWidget.AddService<ICallbackService>(callbackService);
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

            void BuildContextTree(Context parentContext)
            {
                while (iteractor.MoveNext())
                {
                    var widgetAttr = iteractor.Current;

                    if (widgetAttr is VisualAttribute)
                    {
                        var childWidget = WidgetBuilder.Create(widgetAttr);
                        var childContext = childWidget.CreateContext();

                        parentContext.Attach(childContext);
                        lastVisualContext = childContext;

                        if (widgetAttr is ItemAttribute)
                        {
                            // Do nothing
                        }
                        else if (widgetAttr is ScopeAttribute)
                        {
                            BuildContextTree(childContext);
                        }
                    }
                    else if (widgetAttr is StylerAttribute)
                    {
                        var stylerWidget = WidgetBuilder.Create(widgetAttr);
                        var stylerContext = stylerWidget.CreateContext();

                        // Attach styler to lastVisualContext.
                        // Not attach to parentContext is because
                        // we need to let [ItemWidget] can use Styler too.
                        lastVisualContext.Attach(stylerContext);
                    }
                    // Special processing of LogicAttribute
                    else if (widgetAttr is LogicAttribute)
                    {
                        // Terminate the loop at the EndScopeAttribute
                        // to exit building from the parent scope.
                        if (widgetAttr is EndScopeAttribute)
                        {
                            break;
                        }
                    }
                }
            }

            BuildContextTree(parentContext);

            if (iteractor.MoveNext())
            {
                var attr = iteractor.Current;
                var name = attr.GetType().Name;
                if (name.EndsWith("Attribute"))
                {
                    name = name.Remove(name.Length - 9);
                }
                Debug.LogWarning($"The ContextTree has been built, but [{name}] has not been added yet. Please check if there are any surplus [EndScope] before it.");
                //
                // eng:
            }
        }
    }
}
