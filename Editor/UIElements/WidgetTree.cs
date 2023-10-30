using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public class WidgetTreeDrawer : WidgetDrawer
    {
        public WidgetTreeDrawer(UObject target, MemberInfo info, SerializedProperty serializedProperty = null)
        {
            SetWidget(null, this);

            this.target = target;
            this.memberInfo = info;
            this.serializedProperty = serializedProperty?.Copy();
        }

        public override UObject target { get; }

        public override SerializedProperty serializedProperty { get; }

        public override MemberInfo memberInfo { get; }

        internal override Type AttributeType => throw new NotImplementedException();

        internal override DrawerAttribute attributeRef
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        internal bool ShouldBuildAtRoot
        {
            get
            {
                var templateAttribute = memberInfo.GetCustomAttribute<TemplateAttribute>();

                if (templateAttribute == null)
                {
                    return true;
                }

                return templateAttribute.showTemplate;
            }
        }

        internal override Widget CreateWidget()
        {
            var widgetTree = new WidgetTree(this)
            {
                name = $"{memberInfo.Name}'s WidgetTree"
            };

            var targetElement = CreateTargetElement();

            var attrs = memberInfo.GetCustomAttributes<WidgetAttribute>(true).ToList();

            var targetAttributeCount = attrs.Count(attr => attr is TargetAttribute);

            if (targetAttributeCount == 0)
            {
                // Add default target attribute
                attrs.Add(new TargetAttribute());
            }
            else if (targetAttributeCount > 1)
            {
                throw new InvalidOperationException($"Multiple {nameof(TargetAttribute)} found in attributes.");
            }

            var iteractor = attrs.GetEnumerator();

            Widget lastWidget = null;

            List<Widget> DrawWidgets()
            {
                var widgets = new List<Widget>();
                while (iteractor.MoveNext())
                {
                    var current = iteractor.Current;

                    // Draw widget
                    if (current is DrawerAttribute drawerAttr)
                    {
                        if (current is EndScopeAttribute)
                        {
                            break;
                        }

                        var drawer = Templates.Create(drawerAttr, this);
                        var widget = drawer.Widget;

                        lastWidget = widget;
                        widgets.Add(lastWidget);

                        if (drawerAttr is ItemAttribute itemAttribute)
                        {
                            // do nothing
                        }
                        else if (drawerAttr is ScopeAttribute scopeAttr)
                        {
                            var childWidgets = DrawWidgets();
                            foreach (var childWidget in childWidgets)
                            {
                                widget.Add(childWidget);
                            }
                        }

                        widget.SendEvent<IDrawMemeberReceiver>(r => r.OnDrawMember(widget, targetElement));
                    }
                    // Style widget
                    else if (current is StylerAttribute styleAttr)
                    {
                        if (lastWidget == null)
                        {
                            continue;
                        }

                        if (styleAttr is IUseClassable useClassable)
                        {
                            foreach (var className in useClassable.classList)
                            {
                                lastWidget.AddToClassList(className);
                            }
                        }

                        var styler = WidgetStyler.Templates.Create(styleAttr);
                        styler.OnStyling(lastWidget.style);
                    }
                }

                return widgets;
            }

            var widgets = DrawWidgets();

            foreach (var widget in widgets)
            {
                widgetTree.Add(widget);
            }

            if (targetElement is IBuildable buildable)
            {
                buildable.Build();
            }

            return widgetTree;
        }

        internal void RegisterTemplate(TemplateService templateService)
        {
            var templateAttribute = memberInfo.GetCustomAttribute<TemplateAttribute>();
            var name = templateAttribute?.name ?? memberInfo.Name;

            templateService.Add(name, this);
        }

        private VisualElement CreateTargetElement()
        {
            return memberInfo switch
            {
                FieldInfo fieldInfo => new PropertyField(this.serializedProperty),
                PropertyInfo propertyInfo => new PropertyElement(target, propertyInfo),
                MethodInfo methodInfo => new MethodElement(target, methodInfo),
                _ => throw new InvalidOperationException($"Can not clone {nameof(WidgetTree)} because {nameof(memberInfo)} is not a {nameof(FieldInfo)}, {nameof(PropertyInfo)} or {nameof(MethodInfo)}.")
            };
        }
    }

    public class WidgetTree : Widget
    {
        public WidgetTree(WidgetTreeDrawer widgetTreeDrawer)
            : base(widgetTreeDrawer)
        { }
    }
}
