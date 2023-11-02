using Naukri.InspectorMaid.Editor.UIElements;
using System.Collections.Generic;

namespace Naukri.InspectorMaid.Editor.Services
{
    internal class TemplateService
    {
        private readonly Dictionary<string, WidgetTree> templates = new();

        public WidgetTree this[string key]
        {
            get => templates[key];
            set => templates[key] = value;
        }

        public static TemplateService Of(IWidget widget)
        {
            return widget.GetService<TemplateService>();
        }

        public void Add(string key, WidgetTree widgetTree)
        {
            templates.Add(key, widgetTree);
        }

        public void Remove(string key)
        {
            templates.Remove(key);
        }

        public void TryGetValue(string key, out WidgetTree widgetTree)
        {
            templates.TryGetValue(key, out widgetTree);
        }
    }
}
