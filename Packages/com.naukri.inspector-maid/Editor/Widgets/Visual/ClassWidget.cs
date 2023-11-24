using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using Naukri.InspectorMaid.Layout;
using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public partial class ClassWidget : Widget, IContextAttachedReceiver
    {
        public ClassWidget(object target, SerializedProperty serializedProperty)
        {
            this.target = target;
            targetType = target.GetType();
            serializedObject = serializedProperty.serializedObject;
            serializedObjectType = serializedObject.GetType();
            serializedTarget = serializedObject.targetObject;
            this.serializedProperty = serializedProperty;
        }

        public readonly object target;

        public readonly Type targetType;

        public readonly SerializedObject serializedObject;

        public readonly Type serializedObjectType;

        public readonly UObject serializedTarget;

        private readonly SerializedProperty serializedProperty;

        public override Context CreateContext() => new MultiChildContext(this);

        public override VisualElement Build(IBuildContext context)
        {
            var container = new Class().Compose(ve =>
            {
                ve.name = $"class:{targetType.Name}";
                ve.children = context.BuildChildren();
            });

            var settings = IInspectorMaidSettings.Of(context);
            var styleSheets = settings.ImportStyleSheets;

            foreach (var sheet in styleSheets)
            {
                container.styleSheets.Add(sheet);
            }

            return container;
        }

        public SerializedProperty GetSerializedProperty()
        {
            return serializedProperty.Copy();
        }

        public void OnContextAttached(Context context)
        {
            var attrs = target.GetType().GetCustomAttributes<WidgetAttribute>().ToList();

            if (!attrs.Any())
            {
                if (target is UObject uTarget && uTarget == serializedTarget)
                {
                    attrs.Add(new ScriptFieldAttribute());
                }

                attrs.Add(new MembersAttribute());
            }

            InspectorMaidUtility.CreateWidgetContextsAndAttach(context, attrs);
        }

        private class Class : VisualElement { }
    }

    partial class ClassWidget
    {
        public static ClassWidget Of(IBuildContext context)
        {
            return context.GetAncestorWidget<ClassWidget>();
        }
    }
}
