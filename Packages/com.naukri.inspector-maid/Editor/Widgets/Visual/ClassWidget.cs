using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using Naukri.InspectorMaid.Editor.Widgets.Core;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using Naukri.InspectorMaid.Layout;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public partial class ClassWidget : ScopeWidget, IContextAttachedReceiver
    {
        public ClassWidget(UObject target, SerializedObject serializedObject)
        {
            this.target = target;
            this.serializedObject = serializedObject;
        }

        public readonly UObject target;

        public readonly SerializedObject serializedObject;

        public void OnContextAttached(Context context)
        {
            var attrs = target.GetType().GetCustomAttributes<WidgetAttribute>().ToList();

            if (!attrs.Any())
            {
                attrs.Add(new MembersAttribute());
            }

            InspectorMaidUtility.AttachContextOfWidgetsToTree(context, attrs);
        }

        public override VisualElement Build(IBuildContext context)
        {
            var container = new VisualElement().Compose(c =>
            {
                c.children = BuildChildren(context);
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

    partial class ClassWidget
    {
        public static ClassWidget Of(IBuildContext context)
        {
            return context.GetAncestorWidget<ClassWidget>();
        }
    }
}
