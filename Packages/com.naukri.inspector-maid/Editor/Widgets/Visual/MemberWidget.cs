using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public partial class MemberWidget : ScopeWidget, IContextAttachedReceiver
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
            var container = new VisualElement()
            {
                name = info.Name
            };

            BuildChildren(context, (ctx, e) =>
            {
                container.Add(e);
            });

            return container;
        }

        public void OnContextAttached(Context context)
        {
            var attrs = info.GetCustomAttributes<WidgetAttribute>(true).ToList();

            var targetAttributeCount = attrs.Count(attr => attr is TargetAttribute);

            // Add default target attribute at last
            if (targetAttributeCount == 0)
            {
                attrs.Add(new TargetAttribute());
            }

            var iteractor = attrs.GetEnumerator();

            var lastVisualContext = context;

            void BuildContextTree(Context parent)
            {
                while (iteractor.MoveNext())
                {
                    var widgetAttr = iteractor.Current;

                    if (widgetAttr is VisualAttribute)
                    {
                        var childWidget = WidgetTemplates.Create(widgetAttr);
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
                            var stylerWidget = WidgetTemplates.Create(widgetAttr);

                            var stylerContext = stylerWidget.CreateContext();
                            stylerContext.AttachParent(lastVisualContext);
                        }
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
