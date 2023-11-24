using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public partial class MemberWidget : Widget, IContextAttachedReceiver
    {
        public MemberWidget(object target, MemberInfo info, SerializedProperty serializedProperty)
        {
            this.target = target;
            this.info = info;

            // we need to copy serializedProperty, otherwise the target may not work correctly.
            this.serializedProperty = serializedProperty?.Copy();
        }

        public readonly object target;

        public readonly MemberInfo info;

        private readonly SerializedProperty serializedProperty;

        public bool IsTemplate => info.HasAttribute<TemplateAttribute>();

        public SerializedProperty GetSerializedProperty() => serializedProperty.Copy();

        public override Context CreateContext() => new MultiChildContext(this);

        public override VisualElement Build(IBuildContext context)
        {
            var container = CreateContainer().Compose(ve =>
            {
                ve.children = context.BuildChildren();
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

            InspectorMaidUtility.CreateWidgetContextsAndAttach(context, attrs);
        }

        private VisualElement CreateContainer()
        {
            return info switch
            {
                FieldInfo => new Field() { name = $"field:{info.Name}" },
                PropertyInfo => new Property() { name = $"property:{info.Name}" },
                MethodInfo => new Method() { name = $"method:{info.Name}" },
                _ => null
            };
        }

        private class Field : VisualElement { }

        private class Property : VisualElement { }

        private class Method : VisualElement { }
    }

    partial class MemberWidget
    {
        public static MemberWidget Of(IBuildContext context)
        {
            return context.GetAncestorWidget<MemberWidget>();
        }
    }
}
