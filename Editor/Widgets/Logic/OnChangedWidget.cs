using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.Widgets.Visual;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Logic
{
    public class OnChangedWidget : VisualWidgetOf<OnChangedAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var classWidget = ClassWidget.Of(context);
            var memberWidget = MemberWidget.Of(context);

            var serializedTarget = classWidget.serializedTarget;
            var memberName = memberWidget.info.Name;

            void onChanged()
            {
                if (attribute.setDirty)
                {
                    context.RecordAndSetDirty("OnChange Invoked");
                }

                context.InvokeBindingAction();
            }

            var previousValue = context.GetValue(memberName);

            context.ListenValue(memberName, obj =>
            {
                if (!InspectorMaidUtility.IsBoxedValueEqual(obj, previousValue))
                {
                    onChanged();
                    previousValue = obj;
                }
            });

            return null;
        }
    }
}
