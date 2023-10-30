using Naukri.InspectorMaid.Editor.UIElements;
using System.Collections.Generic;

namespace Naukri.InspectorMaid.Editor.Services
{
    internal partial class TemplateService
    {
        private readonly Dictionary<string, WidgetTreeDrawer> templates = new();

        public WidgetTreeDrawer this[string key]
        {
            get => templates[key];
            set => templates[key] = value;
        }

        public void Add(string key, WidgetTreeDrawer widgetTreeDrawer)
        {
            templates.Add(key, widgetTreeDrawer);
        }

        public void Remove(string key)
        {
            templates.Remove(key);
        }

        public void TryGetValue(string key, out WidgetTreeDrawer widgetTreeDrawer)
        {
            templates.TryGetValue(key, out widgetTreeDrawer);
        }
    }

    partial class TemplateService
    {
        public static TemplateService Of(IWidget widget)
        {
            return widget.GetService<TemplateService>();
        }
    }
}
