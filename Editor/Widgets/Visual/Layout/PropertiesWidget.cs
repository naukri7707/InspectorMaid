﻿using Naukri.InspectorMaid.Editor.Services;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using Naukri.InspectorMaid.Layout;
using System.Reflection;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual.Layout
{
    public class PropertiesWidget : VisualWidgetOf<PropertiesAttribute>, IContextAttachedReceiver
    {
        public override VisualElement Build(IBuildContext context)
        {
            var properties = new ComposerOf(new Properties())
            {
                children = context.BuildChildren(),
            };

            return properties;
        }

        public void OnContextAttached(Context context)
        {
            var templateService = IMemberWidgetTemplates.Of(context);

            var widgets = templateService.CreateMemberWidgets(info => info.MemberType == MemberTypes.Property);

            foreach (var widget in widgets)
            {
                if (attribute.skipTemplate && widget.IsTemplate)
                {
                    continue;
                }
                var memberContext = widget.CreateContext();
                context.Attach(memberContext);
            }
        }

        private class Properties : VisualElement { }
    }
}
