﻿using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Services;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public partial class ClassWidget : Widget
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
            var element = new VisualElement()
                .AddChildrenOf(context);

            var settings = IInspectorMaidSettings.Of(context);
            var styleSheets = settings.ImportStyleSheets;

            foreach (var sheet in styleSheets)
            {
                element.styleSheets.Add(sheet);
            }

            return element;
        }

        public override Element CreateElementTree(Element parent)
        {
            var templateService = IMemberWidgetTemplates.Of(parent);

            var element = new Element(this, parent);
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
                        var widgetTree = new MemberWidget(target, fieldInfo, iterator);
                        memberWidgets.Add(widgetTree);
                    }
                }
                while (iterator.NextVisible(false));
            }

            // properties
            var propertyInfos = type.GetPropertiesFromBase(InspectorMaidUtility.BaseType);

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.HasAttribute<InspectorMaidAttribute>())
                {
                    var widgetTree = new MemberWidget(target, propertyInfo);
                    memberWidgets.Add(widgetTree);
                }
            }

            // methods
            var methodInfos = type.GetMethodsFromBase(InspectorMaidUtility.BaseType);

            foreach (var methodInfo in methodInfos)
            {
                if (methodInfo.HasAttribute<InspectorMaidAttribute>())
                {
                    var widgetTree = new MemberWidget(target, methodInfo);
                    memberWidgets.Add(widgetTree);
                }
            }

            // we need to add all member widgets to template service first,
            // so that we can use them in slot
            foreach (var memberWidget in memberWidgets)
            {
                templateService.Add(memberWidget);
            }

            // create script field widget
            scriptFieldWidget.CreateElementTree(element);

            // create member widgets
            foreach (var memberWidget in memberWidgets)
            {
                // don't create template widget
                if (memberWidget.IsTemplate)
                {
                    continue;
                }
                memberWidget.CreateElementTree(element);
            }

            return element;
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