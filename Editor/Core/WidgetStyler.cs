using Naukri.InspectorMaid.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEditor;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class WidgetStyler : IWidgetBuilder
    {
        internal abstract Type AttributeType { get; }

        [SuppressMessage("Style", "IDE1006")]
        internal abstract StylerAttribute attributeRef { get; set; }

        public abstract void OnStyling(IStyle style);

        private WidgetStyler CloneWith(StylerAttribute attribute)
        {
            var cloned = (WidgetStyler)MemberwiseClone();
            cloned.attributeRef = attribute;
            return cloned;
        }

        internal static class Templates
        {
            private static Dictionary<Type, WidgetStyler> _templates;

            internal static WidgetStyler Create(StylerAttribute attribute)
            {
                var template = GetTemplate(attribute);

                var instance = template.CloneWith(attribute);
                return instance;
            }

            private static WidgetStyler GetTemplate(StylerAttribute attribute)
            {
                if (_templates == null)
                {
                    _templates = new Dictionary<Type, WidgetStyler>();
                    var stylerTypes = TypeCache
                        .GetTypesDerivedFrom(typeof(WidgetStyler))
                        .Where(it => !it.IsAbstract).ToList();
                    foreach (var type in stylerTypes)
                    {
                        var inst = (WidgetStyler)Activator.CreateInstance(type);
                        _templates[inst.AttributeType] = inst;
                    }
                }
                var attributeType = attribute.GetType();
                return _templates[attributeType];
            }
        }
    }
}
