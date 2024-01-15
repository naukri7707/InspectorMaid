using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using Naukri.InspectorMaid.Layout;
using System.Linq;
using System.Reflection;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual.Layout
{
    public class BaseWidget : VisualWidgetOf<BaseAttribute>, IContextAttachedReceiver
    {
        public override VisualElement Build(IBuildContext context)
        {
            var members = new ComposerOf(new Base())
            {
                children = context.BuildChildren(),
            };

            return members;
        }

        public void OnContextAttached(Context context)
        {
            var type = (attribute as IDeclaredTypeProvider).DeclaredType.BaseType;

            if (type == null || type == InspectorMaidUtility.kBaseType)
            {
                return;
            }

            var attrs = type.GetCustomAttributes<WidgetAttribute>(false).ToList();

            attrs.RemoveAll(it => it is ScriptFieldAttribute);

            if (!attrs.Any())
            {
                attrs.Add(new BaseAttribute());
                attrs.Add(new MembersAttribute());
            }

            foreach (var attr in attrs)
            {
                if (attr is IDeclaredTypeProvider declaredTypeProvider)
                {
                    declaredTypeProvider.DeclaredType = type;
                }
            }

            InspectorMaidUtility.CreateWidgetContextsAndAttach(context, attrs);
        }

        private class Base : VisualElement { }
    }
}
