using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Widgets.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;

namespace Naukri.InspectorMaid.Editor.Services.Default
{
    internal class MemberWidgetTemplates : IMemberWidgetTemplates
    {
        public MemberWidgetTemplates(object target, SerializedProperty serializedProperty)
        {
            this.target = target;
            this.serializedProperty = serializedProperty.Copy();

            var type = target.GetType();
            var current = serializedProperty.Copy();

            // fields
            if (current.NextVisible(true))
            {
                do
                {
                    // we need to skip unsupported serialized property like m_Script
                    if (current.TryGetFieldInfo(out FieldInfo fieldInfo))
                    {
                        // wrap all field with MemberWidget, even if it is not a widget
                        // so we can inject any target to slot as widget
                        Regisiter(fieldInfo, current);
                    }
                }
                while (current.NextVisible(false));
            }

            // properties
            var propertyInfos = type.GetPropertiesFromBase(InspectorMaidUtility.kBaseType);

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.HasAttribute<WidgetAttribute>())
                {
                    Regisiter(propertyInfo, serializedProperty);
                }
            }

            // methods
            var methodInfos = type.GetMethodsFromBase(InspectorMaidUtility.kBaseType);

            foreach (var methodInfo in methodInfos)
            {
                if (methodInfo.HasAttribute<WidgetAttribute>())
                {
                    Regisiter(methodInfo, serializedProperty);
                }
            }
        }

        private readonly Dictionary<string, (MemberInfo info, SerializedProperty serializedProperty)> _widgetTemplates = new();

        private readonly object target;

        private readonly SerializedProperty serializedProperty;

        public SerializedProperty GetSerializedProperty() => serializedProperty?.Copy();

        public MemberWidget CreateMemberWidget(string memberName)
        {
            var (info, serializedProperty) = _widgetTemplates[memberName];
            return new MemberWidget(target, info, serializedProperty.Copy());
        }

        public MemberWidget[] CreateMemberWidgets(Predicate<MemberInfo> filter = null)
        {
            return _widgetTemplates.Values
                .Where(it => filter?.Invoke(it.info) ?? true)
                .Select(it => new MemberWidget(target, it.info, it.serializedProperty.Copy()))
                .ToArray();
        }

        private void Regisiter(MemberInfo info, SerializedProperty serializedProperty)
        {
            _widgetTemplates.Add(info.Name, (info, serializedProperty.Copy()));
        }
    }
}
