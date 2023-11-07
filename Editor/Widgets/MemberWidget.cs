using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Widgets
{
    public partial class MemberWidget : VisualWidget
    {
        public MemberWidget(MemberWidget template)
            : this(template.target, template.info, template.serializedProperty)
        { }

        public MemberWidget(UObject target, MemberInfo info, SerializedProperty serializedProperty = null)
        {
            this.target = target;
            this.info = info;

            // we need to copy serializedProperty, otherwise the target may not work correctly.
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

        internal override void OnContextAttached(VisualContext context)
        {
            var attrs = info.GetCustomAttributes<InspectorMaidAttribute>(true).ToList();

            var targetAttributeCount = attrs.Count(attr => attr is TargetAttribute);

            // Add default target attribute at last
            if (targetAttributeCount == 0)
            {
                attrs.Add(new TargetAttribute());
            }

            var iteractor = attrs.GetEnumerator();

            var lastContext = context;

            void BuildContextTree(VisualContext parent)
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

                        var subWidget = VisualWidgetTemplates.Create(widgetAttr);
                        var subContext = subWidget.CreateContext();
                        subContext.AttachParent(parent);

                        lastContext = subContext;

                        if (widgetAttr is ItemAttribute itemAttr)
                        {
                            // do nothing
                        }
                        else if (widgetAttr is ScopeAttribute scopeAttr)
                        {
                            BuildContextTree(subContext);
                        }
                    }
                    // Style widget
                    else if (current is StylerAttribute styleAttr)
                    {
                        var styler = StylerWidgetTemplates.Create(styleAttr);

                        var stylerContext = styler.CreateContext();
                        stylerContext.AttachParent(lastContext);
                    }
                }
            }

            BuildContextTree(context);
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
