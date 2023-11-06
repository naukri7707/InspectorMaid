using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public partial class MemberWidget : Widget
    {
        public MemberWidget(MemberWidget template)
            : this(template.target, template.info, template.serializedProperty)
        { }

        public MemberWidget(UObject target, MemberInfo info, SerializedProperty serializedProperty = null)
        {
            this.target = target;
            this.info = info;
            this.serializedProperty = serializedProperty?.Copy();
        }

        public readonly UObject target;

        public readonly MemberInfo info;

        public readonly SerializedProperty serializedProperty;

        public bool IsTemplate => info.HasAttribute<TemplateAttribute>();

        public override VisualElement Build(IBuildContext context)
        {
            return new VisualElement()
            {
                name = info.Name
            }.AddChildrenOf(context);
        }

        // Get all elements that belong to the the target.
        // if target is the closest ancestor MemberWidget of the element, the element is belong to the target.
        public Element[] GetFamily(IBuildContext context)
        {
            var elements = new List<Element>();
            // Todo: rename
            void DFS(IBuildContext ctx)
            {
                ctx.VisitChildElements(child =>
                {
                    if (child.Widget is not MemberWidget)
                    {
                        elements.Add(child);
                        DFS(child);
                    }
                });
            }

            DFS(context);

            return elements.ToArray();
        }

        public override Element CreateElementTree(Element parent)
        {
            var element = new Element(this, parent);

            var attrs = info.GetCustomAttributes<InspectorMaidAttribute>(true).ToList();

            var targetAttributeCount = attrs.Count(attr => attr is TargetAttribute);

            // Add default target attribute at last
            if (targetAttributeCount == 0)
            {
                attrs.Add(new TargetAttribute());
            }

            var iteractor = attrs.GetEnumerator();

            Element lastElement = element;

            void CreateElementTree(Element parent)
            {
                while (iteractor.MoveNext())
                {
                    var current = iteractor.Current;

                    // Draw widget
                    if (current is WidgetAttribute widgetAttr)
                    {
                        if (current is EndScopeAttribute)
                        {
                            break;
                        }

                        var widget = WidgetTemplates.Create(widgetAttr);
                        var element = widget.CreateElementTree(parent);
                        lastElement = element;

                        if (widgetAttr is ItemAttribute itemAttr)
                        {
                            // do nothing
                        }
                        else if (widgetAttr is ScopeAttribute scopeAttr)
                        {
                            CreateElementTree(element);
                        }
                    }
                    // Style widget
                    else if (current is StylerAttribute styleAttr)
                    {
                        var styler = StylerTemplates.Create(styleAttr);
                        lastElement.AddStyler(styler);
                    }
                }
            }

            CreateElementTree(element);

            return element;
        }
    }

    partial class MemberWidget
    {
        public static MemberWidget Of(IBuildContext context)
        {
            return context.GetAncestorWidget<MemberWidget>();
        }
    }
}
