using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.Widgets.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Services.Default
{
    internal class MemberWidgetTemplates : IMemberWidgetTemplates
    {
        public MemberWidgetTemplates(UObject target, SerializedObject serializedObject)
        {
            this.target = target;

            var type = target.GetType();

            // fields
            var iterator = serializedObject.GetIterator();
            if (iterator.NextVisible(true))
            {
                do
                {
                    // we need to skip unsupported serialized property like m_Script
                    if (iterator.TryGetFieldInfo(out FieldInfo fieldInfo))
                    {
                        // wrap all field with MemberWidget, even if it is not a widget
                        // so we can inject any target to slot as widget
                        Regisiter(fieldInfo, iterator);
                    }
                }
                while (iterator.NextVisible(false));
            }

            // properties
            var propertyInfos = type.GetPropertiesFromBase(InspectorMaidUtility.kBaseType);

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.HasAttribute<WidgetAttribute>())
                {
                    Regisiter(propertyInfo);
                }
            }

            // methods
            var methodInfos = type.GetMethodsFromBase(InspectorMaidUtility.kBaseType);

            foreach (var methodInfo in methodInfos)
            {
                if (methodInfo.HasAttribute<WidgetAttribute>())
                {
                    Regisiter(methodInfo);
                }
            }
        }

        private readonly Dictionary<string, (MemberInfo info, SerializedProperty serializedProperty)> _widgetTemplates = new();

        private readonly UObject target;

        public MemberWidget CreateMemberWidget(string memberName)
        {
            var (info, serializedProperty) = _widgetTemplates[memberName];
            return new MemberWidget(target, info, serializedProperty?.Copy());
        }

        public MemberWidget[] CreateMemberWidgets(Predicate<MemberInfo> filter = null)
        {
            return _widgetTemplates.Values
                .Where(it => filter?.Invoke(it.info) ?? true)
                .Select(it => new MemberWidget(target, it.info, it.serializedProperty?.Copy()))
                .ToArray();
        }

        public MemberWidget[] CreateFieldWidgets()
        {
            return CreateMemberWidgets(it => it.MemberType == MemberTypes.Field);
        }

        public MemberWidget[] CreatePropertyWidgets()
        {
            return CreateMemberWidgets(it => it.MemberType == MemberTypes.Property);
        }

        public MemberWidget[] CreateMethodWidgets()
        {
            return CreateMemberWidgets(it => it.MemberType == MemberTypes.Method);
        }

        private void Regisiter(MemberInfo info, SerializedProperty serializedProperty = null)
        {
            _widgetTemplates.Add(info.Name, (info, serializedProperty?.Copy()));
        }
    }
}
