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
    public class WidgetTree : VisualElement, IWidget
    {
        public WidgetTree(UObject target, MemberInfo info, SerializedProperty serializedProperty = null)
        {
            this.target = target;
            this.info = info;
            this.serializedProperty = serializedProperty?.Copy();

            targetElement = info switch
            {
                FieldInfo fieldInfo => new PropertyField(this.serializedProperty),
                PropertyInfo propertyInfo => new PropertyElement(target, propertyInfo),
                MethodInfo methodInfo => new MethodElement(target, methodInfo),
                _ => throw new InvalidOperationException($"Can not clone {nameof(WidgetTree)} because {nameof(info)} is not a {nameof(FieldInfo)}, {nameof(PropertyInfo)} or {nameof(MethodInfo)}.")
            };

            name = $"{info.Name}'s WidgetTree";
        }

        internal readonly UObject target;

        internal readonly MemberInfo info;

        internal readonly SerializedProperty serializedProperty;

        private readonly VisualElement targetElement;

        internal bool ShouldBuildAtRoot
        {
            get
            {
                var templateAttribute = info.GetCustomAttribute<TemplateAttribute>();

                if (templateAttribute == null)
                {
                    return true;
                }

                return templateAttribute.showTemplate;
            }
        }

        public WidgetTree Clone()
        {
            return new WidgetTree(target, info, serializedProperty);
        }

        public void RegisterTemplate()
        {
            var templateService = TemplateService.Of(this);

            var templateAttribute = info.GetCustomAttribute<TemplateAttribute>();
            var name = templateAttribute?.name ?? info.Name;

            templateService.Add(name, this);
        }

        public void Build()
        {
            var attrs = info.GetCustomAttributes<WidgetAttribute>(true).ToList();

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

                        var drawer = WidgetDrawer.Templates.Create(drawerAttr, this);
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
                Add(widget);
            }

            if (targetElement is IBuildable buildable)
            {
                buildable.Build();
            }
        }

        public void SendEvent<TReceiver>(Action<TReceiver> callback) where TReceiver : IReceiver
        {
            this.Query<Widget>().ForEach(w => w.SendEvent(callback));
        }
    }
}
