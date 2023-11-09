using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Naukri.InspectorMaid.Editor.Helpers
{
    internal static class InspectorMaidUtility
    {
        public const BindingFlags kAllAccessFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        public const BindingFlags kAllDeclaredAccessFlags = kAllAccessFlags | BindingFlags.DeclaredOnly;

        // this should be same as InspectorMaidEditor's CustomEditor attribute
        public static readonly Type kBaseType = typeof(MonoBehaviour);

        public static void AttachContextOfWidgetsToTree(Context parentContext, IEnumerable<WidgetAttribute> widgetAttributes)
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
                        childContext.AttachParent(parent);

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
                            stylerContext.AttachParent(lastVisualContext);
                        }
                    }
                }
            }

            BuildContextTree(parentContext);
        }
    }
}
