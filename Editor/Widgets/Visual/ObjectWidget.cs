using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using UnityEditor;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public partial class ObjectWidget : ScopeWidget, IContextAttachedReceiver
    {
        public ObjectWidget(UObject target, SerializedObject serializedObject)
        {
            this.target = target;
            this.serializedObject = serializedObject;
        }

        public UObject target;

        public SerializedObject serializedObject;

        public void OnContextAttached(Context context)
        {
            var templateService = IMemberWidgetTemplates.Of(context);

            // create script field widget
            var scriptFieldWidget = new ScriptFieldWidget(serializedObject.FindProperty("m_Script"));
            var scriptFieldContext = scriptFieldWidget.CreateContext();
            scriptFieldContext.AttachParent(context);

            // create member widgets
            foreach (var memberWidget in templateService.CreateMemberWidgets())
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
    }

    partial class ObjectWidget
    {
        public static ObjectWidget Of(IBuildContext context)
        {
            return context.GetAncestorWidget<ObjectWidget>();
        }
    }
}
