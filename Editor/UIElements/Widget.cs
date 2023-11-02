using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.Receivers;
using Naukri.InspectorMaid.Editor.Services;
using System;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public sealed class Widget : VisualElement, IWidget
    {
        public Widget(WidgetDrawer widgetDrawer) : this(widgetDrawer, "Widget") { }

        public Widget(WidgetDrawer widgetDrawer, string name)
        {
            this.widgetDrawer = widgetDrawer;
            base.name = name;
            RegisterCallback<AttachToPanelEvent>(OnAttachToPanel);
        }

        private readonly WidgetDrawer widgetDrawer;

        internal WidgetLifePhase LifePhase
        {
            get => widgetDrawer.lifePhase;
            set => widgetDrawer.lifePhase = value;
        }

        public void SendEvent<TReceiver>(Action<TReceiver> callback) where TReceiver : IReceiver
        {
            if (widgetDrawer is TReceiver tReceiver)
            {
                callback?.Invoke(tReceiver);
            }
        }

        private void OnAttachToPanel(AttachToPanelEvent evt)
        {
            var lifeCycle = EditorEventService.Of(this);

            lifeCycle.OnSceneGUI += widgetDrawer.OnScenceGUIImpl;
            lifeCycle.OnDestroy += widgetDrawer.OnDestroyImpl;

            widgetDrawer.lifePhase = WidgetLifePhase.Attached;
        }
    }
}
